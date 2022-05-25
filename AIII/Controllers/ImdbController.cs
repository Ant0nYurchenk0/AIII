using AIII.Controllers.Api;
using AIII.Dtos;
using AIII.Repositories;
using AIII.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AIII.Controllers
{
    public class ImdbController : Controller
    {
        private IImdbApiController _api;
        private UserRatingAPIController _userRating;
        private UserRatingRepository _userRatingRepository;
        // GET: Movies
        public ImdbController(ImdbApiController api,
            UserRatingAPIController userRating,
            UserRatingRepository userRatingRepository)
        {
            _api = api;
            _userRating = userRating;
            _userRatingRepository = userRatingRepository;
        }
        public ActionResult GetMovie(string id)
        {
            try
            {
                var movie = new MovieFullInfoDto();

                movie = _api.GetMovie(id);
                if (movie.ImdbRating == null)
                    movie.ImdbRating = 0;

                if (User.Identity.IsAuthenticated)
                    movie.UserRating = _userRating.GetUserRating(id);
                else
                {
                    movie.UserRating = new UserRatingDto(id, _userRatingRepository);

                }

                return View("..\\Movies\\Details", movie);
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException _)
            {
                return View("InvalidKey");
            }
        }
        public ActionResult PopularMovies()
        {
            var movies = new SearchResult();
            movies.Movies = _api.GetPopularMovies().Select(m => Mapper.Map<MovieShortInfoDto>(m));
            if (movies.Movies.Count() == 0)
                return View("InvalidKey");

            return View("..\\Movies\\SearchResult", movies);
        }
        public ActionResult PopularTVs()
        {
            var movies = new SearchResult();
            movies.Movies = _api.GetPopularTVs().Select(m => Mapper.Map<MovieShortInfoDto>(m));
            if (movies.Movies.Count() == 0)
                return View("InvalidKey");
            return View("..\\Movies\\SearchResult", movies);
        }
        public ActionResult TopMovies()
        {
            var movies = new SearchResult();
            movies.Movies = _api.GetTopMovies().Select(m => Mapper.Map<MovieShortInfoDto>(m));
            if (movies.Movies.Count() == 0)
                return View("InvalidKey");
            return View("..\\Movies\\SearchResult", movies);
        }
        public ActionResult TopTVs()
        {
            var movies = new SearchResult();
            movies.Movies = _api.GetTopTVs().Select(m => Mapper.Map<MovieShortInfoDto>(m));
            if (movies.Movies.Count() == 0)
                return View("InvalidKey");
            return View("..\\Movies\\SearchResult", movies);
        }
        [Route("Imdb/Search/")]
        public ActionResult Search(string title, string country, string type, List<string> genres, List<string> releaseDate, List<string> userRating)
        {
            if (AllNulls(title, country, type, genres, releaseDate, userRating))
                return View("Index", "Home");
            var movies = new SearchResult();
            //movies.Movies = _api.Search(title, country, type, genres, releaseDate, userRating);
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