using AIII.Models;
using AIII.Repositories;
using System.Linq;
using System.Web.Mvc;

namespace AIII.Controllers
{
    public class UserRatingController : Controller
    {
        ApplicationDbContext _context;
        UserRatingRepository _repository;

        public UserRatingController()
        {
            _context = new ApplicationDbContext();
            _repository = new UserRatingRepository();  
        }

        public ActionResult IncrementLike(string movieId)
        {
            var userRating = _context.UserMovieRating.FirstOrDefault(r => r.MovieId == movieId && r.UserId == User.Identity.Name);

            _repository.IncrementLike(userRating);
            _context.SaveChanges();

            if (!movieId.StartsWith("aaa"))
                return RedirectToAction("GetMovie", "Imdb", new { id = movieId });
            else
                return RedirectToAction("GetMovie", "CustomMovie", new { id = movieId });
        }

        public ActionResult IncrementDislike(string movieId)
        {
            var userRating = _context.UserMovieRating.FirstOrDefault(r => r.MovieId == movieId && r.UserId == User.Identity.Name);

            _repository.IncrementDislike(userRating);
            _context.SaveChanges();

            if (!movieId.StartsWith("aaa"))
                return RedirectToAction("GetMovie", "Imdb", new {id = movieId});
            else
                return RedirectToAction("GetMovie", "CustomMovie", new { id = movieId });
        }
    }
}