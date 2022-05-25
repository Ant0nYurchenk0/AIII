using AIII.Dtos;
using AIII.Models;
using AIII.Repositories;
using AIII.Service;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AIII.Controllers.Api
{
    public class UserRatingAPIController : ApiController
    {
        ApplicationDbContext _context;
        UserRatingRepository _repository;

        public UserRatingAPIController(ApplicationDbContext context, UserRatingRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        public UserRatingDto GetUserRating(string movieId)
        {
            var userRating = _context.UserMovieRating.FirstOrDefault(r => r.MovieId == movieId && r.UserId == User.Identity.Name);

            if (userRating == null)
            {
                userRating = _repository.UserRatingIsNull(userRating, movieId, User.Identity.Name);

                _context.UserMovieRating.Add(userRating);
                _context.SaveChanges();
            }

            userRating.LikesAmount = _repository.GetAllUserAmountOfLikes(movieId) > 0 ? _repository.GetAllUserAmountOfLikes(movieId) : 0;
            userRating.DislikesAmount = _repository.GetAllUserAmountOfDislikes(movieId) > 0 ? _repository.GetAllUserAmountOfDislikes(movieId) : 0;
            userRating.WatchedAmount = _repository.GetAllUserWatchedAmount(movieId) > 0 ? _repository.GetAllUserWatchedAmount(movieId) : 0;

            var dto = Mapper.Map<UserRating, UserRatingDto>(userRating);

            dto.Watched = _context.UserMovieRating.Any(r => r.MovieId == movieId && r.UserId == User.Identity.Name && r.WatchedAmount > 0);
            dto.Liked = _context.UserMovieRating.Any(r => r.MovieId == movieId && r.UserId == User.Identity.Name && r.LikesAmount > 0);
            dto.Disliked = _context.UserMovieRating.Any(r => r.MovieId == movieId && r.UserId == User.Identity.Name && r.DislikesAmount > 0);

            return dto;
        }
        public List<MovieFullInfoDto> GetMostLiked()
        {
            var movies = _context.UserMovieRating
                .GroupBy(r => r.MovieId)
                .Select(m => new { Likes = m.Sum(r => r.LikesAmount), Id = m.Select(r => r.MovieId).FirstOrDefault().ToString() })
                .Where(r => r.Likes != 0)
                .OrderByDescending(m => m.Likes)
                .ToList();
            var movieDtos = new List<MovieFullInfoDto>();
            foreach (var movie in movies)
            {
                if (Check.IsImdb(movie.Id))
                {
                    var info = _context.MovieShortInfo.First(m => m.Id == movie.Id);
                    if (info.ImdbRating != null)
                        info.ImdbRating = info.ImdbRating.Replace(',', '.');
                    movieDtos.Add(Mapper.Map<MovieFullInfoDto>(Mapper.Map<MovieShortInfoDto>(info)));
                }
                else
                {
                    var info = _context.CustomMovies.First(m => m.Id == movie.Id);
                    movieDtos.Add(Mapper.Map<MovieFullInfoDto>(info));
                }
            }
            return movieDtos;
        }
        public List<MovieFullInfoDto> GetMostWatched()
        {
            var movies = _context.UserMovieRating
                .GroupBy(r => r.MovieId)
                .Select(m => new { Views = m.Sum(r => r.WatchedAmount), Id = m.Select(r => r.MovieId).FirstOrDefault().ToString() })
                .Where(r => r.Views != 0)
                .OrderByDescending(m => m.Views)
                .ToList();
            var movieDtos = new List<MovieFullInfoDto>();
            foreach (var movie in movies)
            {
                if (Check.IsImdb(movie.Id))
                {
                    var info = _context.MovieShortInfo.First(m => m.Id == movie.Id);
                    if(info.ImdbRating !=null)
                        info.ImdbRating = info.ImdbRating.Replace(',', '.');
                    movieDtos.Add(Mapper.Map<MovieFullInfoDto>(Mapper.Map<MovieShortInfoDto>(info)));
                }
                else
                {
                    var info = _context.CustomMovies.First(m => m.Id == movie.Id);
                    movieDtos.Add(Mapper.Map<MovieFullInfoDto>(info));
                }
            }
            return movieDtos;
        }
    }
}
