using AIII.Dtos;
using AIII.Models;
using AIII.Repositories;
using AutoMapper;
using System.Linq;
using System.Web.Http;

namespace AIII.Controllers.Api
{
    public class UserRatingAPIController : ApiController
    {
        ApplicationDbContext _context;
        UserRatingRepository repository;

        public UserRatingAPIController()
        {
            _context = new ApplicationDbContext();
            repository = new UserRatingRepository();
        }

        public UserRatingDto GetUserRating(string movieId)
        {
            var userRating = _context.UserMovieRating.FirstOrDefault(r => r.MovieId == movieId && r.UserId == User.Identity.Name);

            if (userRating == null)
            {
                userRating = repository.UserRatingIsNull(userRating,movieId,User.Identity.Name);
            }
            

            userRating.LikesAmount = repository.GetAllUserAmountOfLikes(movieId) > 0 ? repository.GetAllUserAmountOfLikes(movieId) : 0;
            userRating.DislikesAmount = repository.GetAllUserAmountOfDislikes(movieId) > 0 ? repository.GetAllUserAmountOfDislikes(movieId) : 0;
            userRating.WatchedAmount = repository.GetAllUserWatchedAmount(movieId) > 0 ? repository.GetAllUserWatchedAmount(movieId) : 0;

            var dto = Mapper.Map<UserRating, UserRatingDto>(userRating);

            dto.Watched =_context.UserMovieRating.Any(r => r.MovieId == movieId && r.UserId == User.Identity.Name && r.WatchedAmount > 0);
            dto.Liked = _context.UserMovieRating.Any(r => r.MovieId == movieId && r.UserId == User.Identity.Name && r.LikesAmount > 0);
            dto.Disliked = _context.UserMovieRating.Any(r => r.MovieId == movieId && r.UserId == User.Identity.Name && r.DislikesAmount > 0);

            return dto;
        }
    }
}
