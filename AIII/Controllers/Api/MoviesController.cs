using AIII.Dtos;
using AIII.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AIII.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
        }

        public MovieDto GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.MovieId == id);

            if(movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Movie,MovieDto>(movie);
        }

        [HttpPost]
        public MovieDto CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.MovieId = movie.MovieId;
            return movieDto;
        }

        [HttpPut]
        public void UpdateMovie(int id,MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _context.Movies.SingleOrDefault(m => m.MovieId == id);

            if(movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDto,movieInDb);
            movieInDb.Title = movieDto.Title;
            movieInDb.Poster = movieDto.Poster;
            movieInDb.Year = movieDto.Year;
            movieInDb.Genre = movieDto.Genre;
            movieInDb.Type = movieDto.Type;
            movieInDb.Country = movieDto.Country;
            movieInDb.Cast = movieDto.Cast;
            movieInDb.Plot = movieDto.Plot;
            movieInDb.Budget = movieDto.Budget;
            movieInDb.BoxOffice = movieDto.BoxOffice;
            movieInDb.RatingIMDB = movieDto.RatingIMDB;
            movieInDb.SiteUserRating = movieDto.SiteUserRating;
            movieInDb.GoodEmodjiAmount = movieDto.GoodEmodjiAmount;
            movieInDb.BadEmodjiAmount = movieDto.BadEmodjiAmount;

            _context.SaveChanges();
        }

        [HttpDelete]
        public void RemoveMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.MovieId == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }
    }
}
