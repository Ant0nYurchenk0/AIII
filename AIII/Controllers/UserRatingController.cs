using AIII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIII.Controllers
{
    public class UserRatingController : Controller
    {
        ApplicationDbContext _context;

        public UserRatingController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult IncrementLike(string movieId)
        {
            var userRating = _context.UserMovieRating.FirstOrDefault(r => r.MovieId == movieId && r.UserId == User.Identity.Name);

            if (userRating.LikesAmount == 0)
            {
                userRating.LikesAmount += 1;
                if(userRating.DislikesAmount == 1)
                    userRating.DislikesAmount -= 1;
            }
            else
                userRating.LikesAmount -= 1;

            _context.SaveChanges();

            if (!movieId.StartsWith("aaa"))
                return RedirectToAction("GetMovie", "Imdb", new { id = movieId });
            else
                return RedirectToAction("GetMovie", "CustomMovie", new { id = movieId });
        }

        public ActionResult IncrementDislike(string movieId)
        {
            var userRating = _context.UserMovieRating.FirstOrDefault(r => r.MovieId == movieId && r.UserId == User.Identity.Name);

            if (userRating.DislikesAmount == 0)
            {
                userRating.DislikesAmount += 1;
                if(userRating.LikesAmount == 1)
                    userRating.LikesAmount -= 1;
            }
            else
                userRating.DislikesAmount -= 1;

            _context.SaveChanges();

            if (!movieId.StartsWith("aaa"))
                return RedirectToAction("GetMovie", "Imdb", new {id = movieId});
            else
                return RedirectToAction("GetMovie", "CustomMovie", new { id = movieId });
        }
    }
}