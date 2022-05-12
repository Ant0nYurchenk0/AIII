using AIII.Dtos;
using AIII.Models;
using AIII.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AIII.Controllers.Api
{
    public class ImdbController : ApiController
    {
        private ImdbRepository _repository;
        public ImdbController()
        {
            _repository = new ImdbRepository();
        }

        [HttpGet]
        [Route("Movie")]
        public IHttpActionResult GetMovie(string id)
        {
            var movie = _repository.SearchById(id);
            return Ok(movie);
        }

        [HttpGet]
        [Route("api/imdb/search")]
        public IHttpActionResult Search()
        {
            var param = Request.RequestUri.Query.ToString();
            var movie = _repository.Search(param);
            return Ok(movie);
        }

        [HttpGet]
        [Route("api/imdb/topmovies")]
        public IHttpActionResult GetTopMovies()
        {
            var movie = _repository.TopMovies();
            return Ok(movie);
        }

        [HttpGet]
        [Route("api/imdb/toptvs")]
        public IHttpActionResult GetTopTVs()
        {
            var movie = _repository.TopTVs();
            return Ok(movie);
        }

        [HttpGet]
        [Route("api/imdb/popularmovies")]
        public IHttpActionResult GetPopularMovies()
        {
            var movie = _repository.PopularMovies();
            return Ok(movie);
        }

        [HttpGet]
        [Route("api/imdb/populartvs")]
        public IHttpActionResult GetPopularTVs()
        {
            var movie = _repository.PopularTVs();
            return Ok(movie);
        }
        
    }
}