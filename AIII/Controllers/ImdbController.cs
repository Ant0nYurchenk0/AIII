using AIII.Controllers.Api;
using AIII.Dtos;
using AIII.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            var userRating = new UserRatingAPIController();
            var movie = new MovieFullInfoDto();

            movie = _api.GetMovie(id);
            movie.UserRating = userRating.GetUserRating(id);

            return View("..\\Movies\\Details", movie);
        }
        public ActionResult PopularMovies()
        {
            var movies = new SearchResult();
            movies.Movies = _api.GetPopularMovies();
            movies.SearchString = "Popular IMDB Movies";
            return View("..\\Movies\\SearchResult", movies);
        }
        public ActionResult PopularTVs()
        {
            var movies = new SearchResult();
            movies.Movies = _api.GetPopularTVs();
            movies.SearchString = "Popular IMDB TV series";
            return View("..\\Movies\\SearchResult", movies);
        }
        public ActionResult TopMovies()
        {
            var movies = new SearchResult();
            movies.Movies = _api.GetTopMovies();
            movies.SearchString = "Top Rated IMDB Movies";
            return View("..\\Movies\\SearchResult", movies);
        }
        public ActionResult TopTVs()
        {
            var movies = new SearchResult();
            movies.Movies = _api.GetTopTVs();
            movies.SearchString = "Top Rated IMDB TV series";
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