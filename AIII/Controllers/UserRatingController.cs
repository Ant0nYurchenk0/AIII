using AIII.Dtos;
using AIII.Models;
using AIII.Repositories;
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

            if (!movieId.StartsWith("aaa"))
                return RedirectToAction("GetMovie", "Imdb", new { id = movieId });
            else
                return RedirectToAction("GetMovie", "CustomMovie", new { id = movieId });
        }

        public ActionResult IncrementDislike(string movieId)
        {
            var userRating = _context.UserMovieRating.FirstOrDefault(r => r.MovieId == movieId && r.UserId == User.Identity.Name);

            _repository.IncrementDislike(userRating);
            _context.SaveChanges();

            if (!movieId.StartsWith("aaa"))
                return RedirectToAction("GetMovie", "Imdb", new {id = movieId});
            else
                return RedirectToAction("GetMovie", "CustomMovie", new { id = movieId });
        }
        public ActionResult SetAsWatched(string movieId)
        {
            var userRating = _context.UserMovieRating.FirstOrDefault(r => r.MovieId == movieId && r.UserId == User.Identity.Name);

            _repository.SetAsWatched(userRating);
            _context.SaveChanges();

            if (!movieId.StartsWith("aaa"))
                return RedirectToAction("GetMovie", "Imdb", new { id = movieId });
            else
                return RedirectToAction("GetMovie", "CustomMovie", new { id = movieId });
        }
        public ActionResult GetMostLiked()
        {
            var movies = _context.UserMovieRating
                .GroupBy(r => r.MovieId)
                .Select(m => new { Likes = m.Sum(r => r.LikesAmount), Id = m.Select(r => r.MovieId).FirstOrDefault().ToString() })
                .ToList()
                .OrderByDescending(m=>m.Likes);
            var movieDtos = new List<MovieShortInfoDto>();
            foreach (var movie in movies.Where(r => r.Likes != 0))
            {
                if(movie.Id[0] != 'a')
                {
                    var info = _context.MovieShortInfo.First(m => m.Id == movie.Id);
                    movieDtos.Add(Mapper.Map<MovieShortInfo, MovieShortInfoDto>(info));
                }
                else
                {
                    var info = _context.CustomMovies.First(m => m.Id == movie.Id);
                    movieDtos.Add(Mapper.Map<CustomMovie, MovieShortInfoDto>(info));
                }
            }
            var result = new SearchResult();
            result.Movies = movieDtos;
            result.SearchString = "Most Liked";
            return View("..\\Movies\\SearchResult", result);
        }
        public ActionResult GetMostWatched()
        {
            var movies = _context.UserMovieRating
                .GroupBy(r => r.MovieId)
                .Select(m => new { Views = m.Sum(r => r.WatchedAmount), Id = m.Select(r => r.MovieId).FirstOrDefault().ToString() })
                .ToList()
                .OrderByDescending(m => m.Views);
            var movieDtos = new List<MovieShortInfoDto>();
            foreach (var movie in movies.Where(r => r.Views != 0))
            {
                if (movie.Id[0] != 'a')
                {
                    var info = _context.MovieShortInfo.First(m => m.Id == movie.Id);
                    movieDtos.Add(Mapper.Map<MovieShortInfo, MovieShortInfoDto>(info));
                }
                else
                {
                    var info = _context.CustomMovies.First(m => m.Id == movie.Id);
                    movieDtos.Add(Mapper.Map<CustomMovie, MovieShortInfoDto>(info));
                }
            }
            var result = new SearchResult();
            result.Movies = movieDtos;
            result.SearchString = "Most Watched";
            return View("..\\Movies\\SearchResult", result);
        }

    }
}