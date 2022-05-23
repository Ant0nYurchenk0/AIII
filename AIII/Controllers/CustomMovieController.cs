using AIII.Controllers.Api;
using AIII.Dtos;
using AIII.Models;
using AIII.Repositories;
using AIII.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIII.Controllers
{
    public class CustomMovieController : Controller
    {
        private ApplicationDbContext _context;
        private CustomMoviesAPIController _apiController;
        private UserRatingAPIController _userRatingApi;
        private UserRatingRepository _userRatingRepository;

        public CustomMovieController(UserRatingAPIController userRatingApi, 
            ApplicationDbContext context, 
            CustomMoviesAPIController apiController,
            UserRatingRepository userRatingRepository)
        {
            _context = context;
            _apiController = apiController;
            _userRatingApi = userRatingApi;
            _userRatingRepository = userRatingRepository;
        }

        public ActionResult Index()
        {
            var moviesSerchResult = new SearchResult();

            var movies = _apiController.GetMovies();
            moviesSerchResult.Movies = _apiController.GetShortInfoMovies().ToList();
                
            if(User.IsInRole("Admin") || User.IsInRole("Moderator"))
                return View(movies);
            else
                return View("..\\Movies\\SearchResult", moviesSerchResult);
        }

        public ActionResult NewMovie()
        {
            return View("CustomMovieForm");
        }

        public ActionResult Edit(string id)
        {
            var customMovie = _context.CustomMovies.SingleOrDefault(m => m.Id == id);

            if (customMovie == null)
                return HttpNotFound();

            return View("CustomMovieForm", customMovie);
        }

        public ActionResult Delete(string id)
        {

            _apiController.DeleteMovie(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Save(CustomMovie customMovie)
        {
            if(!ModelState.IsValid)
                return View("CustomMovieForm", customMovie);

            if(customMovie.Id == null) 
            {
                customMovie.Id = CustomMovieRepository.GetId();
                _context.CustomMovies.Add(customMovie);
            }
            else
            {
                var customMovieInDb = _context.CustomMovies.Single(m => m.Id == customMovie.Id);

                Mapper.Map(customMovie, customMovieInDb);
            }

            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }

        public ActionResult GetMovie(string id)
        {
            var movie = new MovieFullInfoDto();

            movie = _apiController.GetMovie(id);
            if (User.Identity.IsAuthenticated)
                movie.UserRating = _userRatingApi.GetUserRating(id);
            else
            {
                movie.UserRating = new UserRatingDto(id, _userRatingRepository);
            }

            return View("..\\Movies\\Details", movie);
        }
    }
}