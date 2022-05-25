using AIII.Dtos;
using AIII.Models;
using AIII.Repositories;
using AIII.Service;
using AIII.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AIII.Controllers
{
    public class UserRatingController : Controller
    {
        ApplicationDbContext _context;
        UserRatingRepository _repository;

        public UserRatingController(ApplicationDbContext context, UserRatingRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        public ActionResult IncrementLike(string movieId)
        {

            var userRating = _context.UserMovieRating.FirstOrDefault(r => r.MovieId == movieId && r.UserId == User.Identity.Name);

            _repository.IncrementLike(userRating);
            _context.SaveChanges();

            if (Check.IsImdb(movieId))

                return RedirectToAction("GetMovie", "Imdb", new { id = movieId });
            else
                return RedirectToAction("GetMovie", "CustomMovie", new { id = movieId });
        }

        public ActionResult IncrementDislike(string movieId)
        {
            var userRating = _context.UserMovieRating.FirstOrDefault(r => r.MovieId == movieId && r.UserId == User.Identity.Name);

            _repository.IncrementDislike(userRating);
            _context.SaveChanges();

            if (Check.IsImdb(movieId))
                return RedirectToAction("GetMovie", "Imdb", new { id = movieId });
            else
                return RedirectToAction("GetMovie", "CustomMovie", new { id = movieId });
        }
        public ActionResult SetAsWatched(string movieId)
        {
            var userRating = _context.UserMovieRating.FirstOrDefault(r => r.MovieId == movieId && r.UserId == User.Identity.Name);

            _repository.SetAsWatched(userRating);
            _context.SaveChanges();

            if (Check.IsImdb(movieId))

                return RedirectToAction("GetMovie", "Imdb", new { id = movieId });
            else
                return RedirectToAction("GetMovie", "CustomMovie", new { id = movieId });
        }
        

    }
}