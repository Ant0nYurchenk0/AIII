using AIII.Controllers.Api;
using AIII.Dtos;
using AIII.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using AIII.Models;
using AIII.Repositories;

namespace AIII.Controllers
{
    public class ImdbController : Controller
    {
        private IImdbApiController _api;
        // GET: Movies
        public ImdbController()
        {
            _api = new ImdbApiController();
        }
        public ActionResult GetMovie(string id)
        {
            try
            {
            var userRating = new UserRatingAPIController();
            var movie = new MovieFullInfoDto();

            movie = _api.GetMovie(id);
            if (movie.ImdbRating == null)
                movie.ImdbRating = 0;
            if(User.Identity.IsAuthenticated)
                movie.UserRating = userRating.GetUserRating(id);
            else
            {
                var userRatingRepository = new UserRatingRepository();
                movie.UserRating = new UserRatingDto();
                movie.UserRating.LikesAmount = userRatingRepository.GetAllUserAmountOfLikes(id);
                movie.UserRating.DislikesAmount = userRatingRepository.GetAllUserAmountOfDislikes(id);
            }

                return View("..\\Movies\\Details", movie);
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
            {
                return View("InvalidKey");
            }
        }
        public ActionResult PopularMovies()
        {
            var movies = new SearchResult();
            movies.Movies = _api.GetPopularMovies();
            movies.SearchString = "Popular IMDB Movies";
            if(movies.Movies.Count == 0)
                return View("InvalidKey");

            return View("..\\Movies\\SearchResult", movies);
        }
        public ActionResult PopularTVs()
        {
            var movies = new SearchResult();
            movies.Movies = _api.GetPopularTVs();
            movies.SearchString = "Popular IMDB TV series";
            if (movies.Movies.Count == 0)
                return View("InvalidKey");
            return View("..\\Movies\\SearchResult", movies);
        }
        public ActionResult TopMovies()
        {
            var movies = new SearchResult();
            movies.Movies = _api.GetTopMovies();
            movies.SearchString = "Top Rated IMDB Movies";
            if (movies.Movies.Count == 0)
                return View("InvalidKey");
            return View("..\\Movies\\SearchResult", movies);
        }
        public ActionResult TopTVs()
        {
            var movies = new SearchResult();
            movies.Movies = _api.GetTopTVs();
            movies.SearchString = "Top Rated IMDB TV series";
            if (movies.Movies.Count == 0)
                return View("InvalidKey");
            return View("..\\Movies\\SearchResult", movies);
        }
        [Route("Imdb/Search/")]
        public ActionResult Search(string title, string country, string type, List<string> genres, List<string> releaseDate, List<string> userRating)
        {            
            if(AllNulls(title, country, type, genres, releaseDate, userRating))
                return View("Index", "Home");
            var movies = new SearchResult();
            movies.Movies = _api.Search(title, country, type, genres, releaseDate, userRating);
            movies.SearchString = title;
            return View("..\\Movies\\SearchResult", movies);
        }

        private bool AllNulls(params object[] parameters)
        {
            foreach (var item in parameters)
                if (item != null)
                    return false;
            return true;
        }

    }
}