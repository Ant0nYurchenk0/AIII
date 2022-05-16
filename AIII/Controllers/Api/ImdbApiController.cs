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
    public class ImdbApiController : ApiController, IImdbApiController
    {
        private ImdbRepository _repository;
        public ImdbApiController()
        {
            _repository = new ImdbRepository();
        }

        [HttpGet]
        [Route("api/imdb/movie")]
        public MovieFullInfoDto GetMovie(string id)
        {
            var movie = _repository.SearchById(id);
            return movie;
        }

        [HttpGet]
        [Route("api/imdb/search")]
        public List<MovieShortInfoDto> Search(string title, string country, string type, List<string> genres, List<string> releaseDate)
        {            
            title = title.Trim();
            var genreStr = genres == null ? null : string.Join(",", genres);
            var releaseDateStr = releaseDate == null ? null : string.Join(",",releaseDate);
            var param = "?"
                + (string.IsNullOrEmpty(title) ? string.Empty : "title=" + title + "&")
                + (string.IsNullOrEmpty(type) ? string.Empty : "title_type=" + type + "&")
                + (string.IsNullOrEmpty(genreStr) ? string.Empty : "genres=" + genreStr + "&")
                + (string.IsNullOrEmpty(country) ? string.Empty : "countries=" + country + "&")
                + (string.IsNullOrEmpty(releaseDateStr) ? string.Empty : "release_date=" + releaseDateStr + "&");
            var movies = _repository.Search(param);
            return movies;
        }

        [HttpGet]
        [Route("api/imdb/topmovies")]
        public List<MovieShortInfoDto> GetTopMovies()
        {
            var movies = _repository.TopMovies();
            return movies;
        }

        [HttpGet]
        [Route("api/imdb/toptvs")]
        public List<MovieShortInfoDto> GetTopTVs()
        {
            var movie = _repository.TopTVs();
            return movie;
        }

        [HttpGet]
        [Route("api/imdb/popularmovies")]
        public List<MovieShortInfoDto> GetPopularMovies()
        {
            var movie = _repository.PopularMovies();
            return movie;
        }

        [HttpGet]
        [Route("api/imdb/populartvs")]
        public List<MovieShortInfoDto> GetPopularTVs()
        {
            var movie = _repository.PopularTVs();
            return movie;
        }

    }
}