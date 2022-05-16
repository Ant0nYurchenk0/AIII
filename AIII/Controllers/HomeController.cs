using AIII.Controllers.Api;
using AIII.Repositories;
using AIII.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;



namespace AIII.Controllers
{
    public class HomeController : Controller
    {
        IImdbApiController _imdbApi;
        CustomMoviesAPIController _customApi;
        public HomeController()
        {
            _imdbApi = new ImdbApiController();
            _customApi = new CustomMoviesAPIController();
        }

        public ActionResult Index()
        {
            var movies = new HomeMovies();
            movies.PopularMovies = _imdbApi.GetPopularMovies().Take(10).ToList();
            movies.PopularTVs = _imdbApi.GetPopularTVs().Take(10).ToList();
            movies.CustomMovies = _customApi.GetShortInfoMovies().Take(10).ToList();
            return View(movies);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ShowImdbMovie(string id)
        {
            return View();
        }
    }
}