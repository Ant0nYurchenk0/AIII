using AIII.Dtos;
using AIII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIII.Repositories
{
    public class UserRatingRepository
    {
        ApplicationDbContext _context;

        public UserRatingRepository()
        {
            _context = new ApplicationDbContext();
        }

        public UserRating UserRatingIsNull(UserRating userRating, string movieId, string userName)
        {
            userRating = new UserRating();

            userRating.MovieId = movieId;
            userRating.UserId = userName;
            userRating.LikesAmount = 0;
            userRating.DislikesAmount = 0;
            userRating.WatchedAmount = 0;

            _context.UserMovieRating.Add(userRating);
            _context.SaveChanges();

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

        public int GetUserAmountOfLikes(string iserId)
        {
            return _context.UserMovieRating.Where(u => u.UserId == iserId).Count(likes => likes.LikesAmount > 0);
        }
        public int GetUserAmountOfDislikes(string iserId)
        {
            return _context.UserMovieRating.Where(u => u.UserId == iserId).Count(likes => likes.DislikesAmount > 0);
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

        internal void SetAsWatched(UserRating userRating)
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