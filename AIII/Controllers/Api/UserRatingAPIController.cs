using AIII.Dtos;
using AIII.Models;
using AutoMapper;
using System.Linq;
using System.Web.Http;

namespace AIII.Controllers.Api
{
    public class UserRatingAPIController : ApiController
    {
        ApplicationDbContext _context;

        public UserRatingAPIController()
        {
            _context = new ApplicationDbContext();
        }

        public UserRatingDto GetUserRating(string movieId)
        {
            var userRating = _context.UserMovieRating.FirstOrDefault(r => r.MovieId == movieId );

            if (userRating == null)
            {
                userRating = new UserRating();

                userRating.MovieId = movieId;
                userRating.LikesAmount = 0;
                userRating.DislikesAmount = 0;
                userRating.UserId = User.Identity.Name;

                _context.UserMovieRating.Add(userRating);
                _context.SaveChanges();
            }
            else
            {
                userRating.LikesAmount = _context.UserMovieRating.Where(r => r.MovieId == movieId).Count(likes => likes.LikesAmount > 0);
                userRating.DislikesAmount = _context.UserMovieRating.Where(r => r.MovieId == movieId).Count(Dislikes => Dislikes.DislikesAmount > 0);
            }

            return Mapper.Map<UserRating, UserRatingDto>(userRating);
        }
    }
}
