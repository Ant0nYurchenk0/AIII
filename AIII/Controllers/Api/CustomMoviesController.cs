﻿using AIII.Dtos;
using AIII.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AIII.Controllers.Api
{
    public class CustomMoviesController : ApiController
    {
        private IAlllDbContext _context;
        public CustomMoviesController(IAlllDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MovieFullInfoDto> GetMovies()
        {
            return _context.CustomMovies.ToList().Select(Mapper.Map<CustomMovie, MovieFullInfoDto>);
        }

        public MovieFullInfoDto GetMovie(string id)
        {
            var movie = _context.CustomMovies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<CustomMovie, MovieFullInfoDto>(movie);
        }

        [HttpPost]
        public MovieFullInfoDto CreateMovie(MovieFullInfoDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movie = Mapper.Map<MovieFullInfoDto, CustomMovie>(movieDto);
            _context.CustomMovies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return movieDto;
        }

        [HttpPut]
        public void UpdateMovie(string id, MovieFullInfoDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _context.CustomMovies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDto, movieInDb);
            movieInDb.Title = movieDto.Title;
            movieInDb.Image = movieDto.Image;
            movieInDb.ReleaseDate= movieDto.ReleaseDate;
            movieInDb.Genres = movieDto.Genres;
            movieInDb.Type = movieDto.Type;
            movieInDb.Countries = movieDto.Countries;
            movieInDb.Stars = movieDto.Stars;
            movieInDb.Plot = movieDto.Plot;
            movieInDb.Budget = movieDto.Budget;

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteMovie(string id)
        {
            var movieInDb = _context.CustomMovies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.CustomMovies.Remove(movieInDb);
            _context.SaveChanges();
        }
    }
}