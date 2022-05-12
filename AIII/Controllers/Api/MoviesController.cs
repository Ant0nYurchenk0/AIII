using AIII.Dtos;
using AIII.Models;
using AutoMapper;
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

        public IEnumerable<CustomMovieDto> GetMovies()
        {
            return _context.CustomMovies.ToList().Select(Mapper.Map<CustomMovie, CustomMovieDto>);
        }

        public CustomMovieDto GetMovie(int id)
        {
            var movie = _context.CustomMovies.SingleOrDefault(m => m.MovieId == id);

            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<CustomMovie, CustomMovieDto>(movie);
        }

        [HttpPost]
        public CustomMovieDto CreateMovie(CustomMovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movie = Mapper.Map<CustomMovieDto, CustomMovie>(movieDto);
            _context.CustomMovies.Add(movie);
            _context.SaveChanges();

            movieDto.MovieId = movie.MovieId;
            return movieDto;
        }

        [HttpPut]
        public void UpdateMovie(int id, CustomMovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _context.CustomMovies.SingleOrDefault(m => m.MovieId == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDto, movieInDb);
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

            _context.SaveChanges();
        }

        [HttpDelete]
        public void RemoveMovie(int id)
        {
            var movieInDb = _context.CustomMovies.SingleOrDefault(m => m.MovieId == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.CustomMovies.Remove(movieInDb);
            _context.SaveChanges();
        }
    }
}
