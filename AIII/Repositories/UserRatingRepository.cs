using AIII.Models;
using System.Collections.Generic;
using System.Linq;

namespace AIII.Repositories
{
    public class UserRatingRepository
    {
        ApplicationDbContext _context;

        public UserRatingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public UserRating UserRatingIsNull(UserRating userRating, string movieId, string userName)
        {
            userRating = new UserRating();

            userRating.MovieId = movieId;
            userRating.UserId = userName;
            userRating.LikesAmount = 0;
            userRating.DislikesAmount = 0;
            userRating.WatchedAmount = 0;

            return userRating;
        }

        public int GetAllUserAmountOfLikes(string movieId)
        {
            return _context.UserMovieRating.Where(r => r.MovieId == movieId).Count(likes => likes.LikesAmount > 0);
        }

        public int GetAllUserAmountOfDislikes(string movieId)
        {
            return _context.UserMovieRating.Where(r => r.MovieId == movieId).Count(Dislikes => Dislikes.DislikesAmount > 0);
        }
        public int GetAllUserWatchedAmount(string movieId)
        {
            return _context.UserMovieRating.Where(r => r.MovieId == movieId).Count(Watched => Watched.WatchedAmount > 0);
        }

        public List<string> GetUserLikedMoviesId(string userId)
        {
            return _context.UserMovieRating
                .Where(u => u.UserId == userId && u.LikesAmount > 0)
                .Select(m => m.MovieId).Distinct().ToList();
        }
        public List<string> GetUserDislikedMoviesId(string userId)
        {
            return _context.UserMovieRating
                .Where(u => u.UserId == userId && u.DislikesAmount > 0)
                .Select(m => m.MovieId).Distinct().ToList();
        }

        public List<string> GetUserWatchedMoviesId(string userId)
        {
            return _context.UserMovieRating
                .Where(u => u.UserId == userId && u.WatchedAmount > 0)
                .Select(m => m.MovieId).Distinct().ToList();
        }

        public void IncrementLike(UserRating userRating)
        {
            if (userRating.LikesAmount == 0)
            {
                userRating.LikesAmount += 1;
                if (userRating.DislikesAmount == 1)
                    userRating.DislikesAmount -= 1;
            }
            else
                userRating.LikesAmount -= 1;
        }

        public void IncrementDislike(UserRating userRating)
        {
            if (userRating.DislikesAmount == 0)
            {
                userRating.DislikesAmount += 1;
                if (userRating.LikesAmount == 1)
                    userRating.LikesAmount -= 1;
            }
            else
                userRating.DislikesAmount -= 1;
        }

        public void SetAsWatched(UserRating userRating)
        {
            if (userRating.WatchedAmount == 0)
            {
                userRating.WatchedAmount += 1;
            }
            else
                userRating.WatchedAmount -= 1;
        }
    }
}