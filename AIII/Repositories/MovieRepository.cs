using AIII.Dtos;
using AIII.Models;
using System.Collections.Generic;
using System.Linq;

namespace AIII.Repositories
{
    public class MovieRepository
    {
        private ApplicationDbContext _context;
        public MovieRepository()
        {
            _context = new ApplicationDbContext();
        }

        public MovieShortInfoDto GetMovieById(string id)
        {
            if (_context.MovieShortInfo.Any(m => m.Id == id))
            {
                var movie = _context.MovieShortInfo
                    .FirstOrDefault(x => x.Id == id);
                return new MovieShortInfoDto
                {
                    Id = id,
                    Image = movie.Image,
                    Title = movie.Title,
                    ImdbRating = movie.ImdbRating
                };
            }
            else if (_context.CustomMovies.Any(m => m.Id == id))
            {
                var movie = _context.CustomMovies
                    .FirstOrDefault(customMovie => customMovie.Id == id);
                return new MovieShortInfoDto
                {
                    Id = id,
                    Image = movie.Image,
                    Title = movie.Title,
                };
            }
            else return null;
        }

        public List<MovieShortInfoDto> GetMoviesByIds(List<string> moviesIds)
        {
            List<MovieShortInfoDto> movies = new List<MovieShortInfoDto>();
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