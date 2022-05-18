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
            var userRating = _context.UserMovieRating.FirstOrDefault(r => r.MovieId == movieId);

            return Mapper.Map<UserRating, UserRatingDto>(userRating);
        }
    }
}
