﻿using AIII.Controllers.Api;
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

        public ActionResult TopMovies()
        {
            var movies = new SearchResult();
            movies.Movies = _api.GetTopMovies();
            movies.SearchString = "Top Rated IMDB Movies";
            return View("..\\Movies\\SearchResult", movies);
        }
        public ActionResult TopTVs(string id)
        {
            var movies = new SearchResult();
            movies.Movies = _api.GetTopTVs();
            movies.SearchString = "Top Rated IMDB TV series";
            return View("..\\Movies\\SearchResult", movies);
        }
        [Route("Imdb/Search/")]
        public ActionResult Search(string title, string country, string type, List<string> genres, List<string> releaseDate)
        {
            var movies = new SearchResult();
            movies.Movies = _api.Search(title, country, type, genres, releaseDate);
            movies.SearchString = title;
            return View("..\\Movies\\SearchResult", movies);
        }
        public ActionResult RateMovie(string id)
        {

            return RedirectToAction("ShowMovie", new { id = id});
        }
    }
}