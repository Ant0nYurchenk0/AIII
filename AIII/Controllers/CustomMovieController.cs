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

        public CustomMovieController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            _apiController = new CustomMoviesAPIController();
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
            _apiController = new CustomMoviesAPIController();

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
            _apiController = new CustomMoviesAPIController();
            var userRatingApi = new UserRatingAPIController();
            var movie = new MovieFullInfoDto();

            movie = _apiController.GetMovie(id);
            if (User.Identity.IsAuthenticated)
                movie.UserRating = userRatingApi.GetUserRating(id);
            else
            {
                var userRatingRepository = new UserRatingRepository(_context);
                movie.UserRating = new UserRatingDto(id, userRatingRepository);
            }

            return View("..\\Movies\\Details", movie);
        }
    }
}