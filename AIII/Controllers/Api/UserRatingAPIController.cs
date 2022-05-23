using AIII.Dtos;
using AIII.Models;
using AIII.Repositories;
using AIII.ViewModels;
using AutoMapper;
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

            dto.Watched =_context.UserMovieRating.Any(r => r.MovieId == movieId && r.UserId == User.Identity.Name && r.WatchedAmount > 0);
            dto.Liked = _context.UserMovieRating.Any(r => r.MovieId == movieId && r.UserId == User.Identity.Name && r.LikesAmount > 0);
            dto.Disliked = _context.UserMovieRating.Any(r => r.MovieId == movieId && r.UserId == User.Identity.Name && r.DislikesAmount > 0);

            return dto;
        }
    }
}
