using AIII.Dtos;
using AIII.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AIII.Repositories
{
    public class MovieRepository
    {
        private ApplicationDbContext _context;
        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public MovieFullInfoDto GetMovieById(string id)
        {
            if (_context.MovieShortInfo.Any(m => m.Id == id))
            {
                var movie = _context.MovieShortInfo
                    .FirstOrDefault(x => x.Id == id);
                return new MovieFullInfoDto
                {
                    Id = id,
                    Image = movie.Image,
                    Title = movie.Title,
                    ImdbRating = Convert.ToDouble(movie.ImdbRating)
                };
            }
            else if (_context.CustomMovies.Any(m => m.Id == id))
            {
                var movie = _context.CustomMovies
                    .FirstOrDefault(customMovie => customMovie.Id == id);
                return new MovieFullInfoDto
                {
                    Id = id,
                    Image = movie.Image,
                    Title = movie.Title,
                };
            }
            else return null;
        }

        public List<MovieFullInfoDto> GetMoviesByIds(List<string> moviesIds)
        {
            var movies = new List<MovieFullInfoDto>();
            foreach (string id in moviesIds)
            {
                var movie = GetMovieById(id);
                if (movie != null)
                {
                    movies.Add(movie);
                }
            }
            return movies;
        }
    }

}