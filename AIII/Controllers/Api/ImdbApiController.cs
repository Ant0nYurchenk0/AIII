﻿using AIII.Dtos;
using AIII.Imdb_Api;
using AIII.Models;
using AIII.Repositories;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AIII.Controllers.Api
{
    public class ImdbApiController : ApiController, IImdbApiController
    {
        private ImdbRepository _repository;
        public ImdbApiController(ImdbRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("api/imdb/movie")]
        public MovieFullInfoDto GetMovie(string id)
        {
            var movie = _repository.SearchById(id, GetImdbKey());
            _repository.SaveMovie(movie);
            return movie;
        }

        [HttpGet]
        [Route("api/imdb/search")]
        public List<MovieFullInfoDto> Search(string title, string country, string type, List<string> genres, List<string> releaseDate, List<string> userRating)
        {
            title = title.Trim();
            var genreStr = genres == null || genres.Count == 0 ? null : string.Join(",", genres);
            var releaseDateStr = releaseDate == null || releaseDate.Count == 0 ? null : string.Join(",", releaseDate);
            var userRatingStr = userRating == null || userRating.Count == 0 ? null : string.Join(",", userRating);
            var param = "?"
                + (string.IsNullOrEmpty(title) ? string.Empty : "title=" + title + "&")
                + (string.IsNullOrEmpty(type) ? string.Empty : "title_type=" + type + "&")
                + (string.IsNullOrEmpty(genreStr) ? string.Empty : "genres=" + genreStr + "&")
                + (string.IsNullOrEmpty(country) ? string.Empty : "countries=" + country + "&")
                + (string.IsNullOrEmpty(userRatingStr) ? string.Empty : "user_rating=" + userRatingStr + "&")
                + (string.IsNullOrEmpty(releaseDateStr) ? string.Empty : "release_date=" + releaseDateStr + "&");
            var movies = _repository.Search(param, GetImdbKey()) ?? new List<MovieFullInfoDto>();
            return movies;
        }

        [HttpGet]
        [Route("api/imdb/topmovies")]
        public List<MovieFullInfoDto> GetTopMovies()
        {
            var movies = _repository.TopMovies(GetImdbKey());
            return movies;
        }

        [HttpGet]
        [Route("api/imdb/toptvs")]
        public List<MovieFullInfoDto> GetTopTVs()
        {
            var movie = _repository.TopTVs(GetImdbKey());
            return movie;
        }

        [HttpGet]
        [Route("api/imdb/popularmovies")]
        public List<MovieFullInfoDto> GetPopularMovies()
        {
            var movie = _repository.PopularMovies(GetImdbKey());
            return movie;
        }

        [HttpGet]
        [Route("api/imdb/populartvs")]
        public List<MovieFullInfoDto> GetPopularTVs()
        {
            var movie = _repository.PopularTVs(GetImdbKey());
            return movie;
        }

        private string GetImdbKey()
        {

            var manager = new ApplicationDbContext();
            var userId = User.Identity.GetUserId();
            if (userId == null)
                return Imdb.DefaultKey;
            var key = manager.Users.Single(u => u.Id == userId).ImdbKey;
            return key;
        }

    }
}