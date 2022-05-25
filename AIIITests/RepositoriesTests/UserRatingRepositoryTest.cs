using AIII.Models;
using AIII.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AIIITests.RepositoriesTests
{
    [TestFixture]
    public class UserRatingRepositoryTest
    {
        private ApplicationDbContext _context;
        UserRatingRepository _userRepository;

        [SetUp]
        public void Setup()
        {
            var fakeDBContext = new Mock<ApplicationDbContext>();
            fakeDBContext.Object.UserMovieRating = SetUpUserRatings().Object;
            _context = fakeDBContext.Object;

            _userRepository = new UserRatingRepository(_context,new MovieRepository(_context));
        }

        [Test]
        public void GetAllUserAmountOfLikes_DbContextHasTwoUsersWithLikeForMovieWithId1_ReturnTwo()
        {
            var movieId = "1";

            var result = _userRepository.GetAllUserAmountOfLikes(movieId);

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void GetAllUserAmountOfDislikes_DbContextHasTwoUsersWithDislikeForMovieWithId2_ReturnTwo()
        {
            var movieId = "2";

            var result = _userRepository.GetAllUserAmountOfDislikes(movieId);

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void GetAllUserWatchedAmount_DbContextHasTwoUsersWhoWatchedMovieWithId1_ReturnTwo()
        {
            var movieId = "1";

            var result = _userRepository.GetAllUserWatchedAmount(movieId);

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void GetUserLikedMoviesId_UserWithId1LikedOneFilm_ReturnListWithIdOne()
        {
            var userId = "1";

            var result = _userRepository.GetUserLikedMoviesId(userId);

            Assert.That(result.Contains("1"));
        }

        [Test]
        public void GetUserDislikedMoviesId_UserWithId1DislikedOneFilm_ReturnListWithIdTwo()
        {
            var userId = "1";

            var result = _userRepository.GetUserDislikedMoviesId(userId);

            Assert.That(result.Contains("2"));
        }

        [Test]
        public void IncrementLike_UserRatingLikeAmountEquelTo0_UserRatingLikeAmountEquelTo1()
        {
            UserRating userRating = new UserRating() { LikesAmount = 0 };

            _userRepository.IncrementLike(userRating);

            Assert.That(userRating.LikesAmount, Is.EqualTo(1));
        }

        [Test]
        public void IncrementLike_UserRatingLikeAmountEquelTo1_UserRatingLikeAmountEquelTo0()
        {
            UserRating userRating = new UserRating() { LikesAmount = 1 };

            _userRepository.IncrementLike(userRating);

            Assert.That(userRating.LikesAmount, Is.EqualTo(0));
        }

        [Test]
        public void IncrementLike_UserRatingLikeAmountEquelTo0AndDislikeAmountEquelTo1_UserRatingLikeAmountEquelTo1DislikeAmountEquelTo0()
        {
            UserRating userRating = new UserRating() { LikesAmount = 0, DislikesAmount = 1 };

            _userRepository.IncrementLike(userRating);

            Assert.That(userRating.LikesAmount, Is.EqualTo(1));
            Assert.That(userRating.DislikesAmount, Is.EqualTo(0));
        }

        [Test]
        public void IncrementDislike_UserRatingDislikeAmountEquelTo0_UserRatingDislikeAmountEquelTo1()
        {
            UserRating userRating = new UserRating() { DislikesAmount = 0 };

            _userRepository.IncrementDislike(userRating);

            Assert.That(userRating.DislikesAmount, Is.EqualTo(1));
        }

        [Test]
        public void IncrementDislike_UserRatingDislkeAmountEquelTo1_UserRatingDisikeAmountEquelTo0()
        {
            UserRating userRating = new UserRating() { DislikesAmount = 1 };

            _userRepository.IncrementDislike(userRating);

            Assert.That(userRating.DislikesAmount, Is.EqualTo(0));
        }

        [Test]
        public void IncrementDislike_UserRatingDisikeAmountEquelTo0AndLikeAmountEquelTo1_UserRatingDislikeAmountEquelTo1LikeAmountEquelTo0()
        {
            UserRating userRating = new UserRating() { LikesAmount = 1, DislikesAmount = 0 };

            _userRepository.IncrementDislike(userRating);

            Assert.That(userRating.LikesAmount, Is.EqualTo(0));
            Assert.That(userRating.DislikesAmount, Is.EqualTo(1));
        }

        [Test]
        public void SetAsWatched_UserRatingWatchedAmountEquelTo0_UserRatingWatchedAmountEquelTo1()
        {
            UserRating userRating = new UserRating() { WatchedAmount = 0 };

            _userRepository.SetAsWatched(userRating);

            Assert.That(userRating.WatchedAmount, Is.EqualTo(1));
        }

        [Test]
        public void SetAsWatched_UserRatingWatchedAmountEquelTo1_UserRatingWatchedAmountEquelTo0()
        {
            UserRating userRating = new UserRating() { WatchedAmount = 1 };

            _userRepository.SetAsWatched(userRating);

            Assert.That(userRating.WatchedAmount, Is.EqualTo(0));
        }

        [Test]
        public void UserRatingIsNull_WhenCalled_ReturnNewUserRatingObjectWithDefaulfValues()
        {
            UserRating userRating = null;

            userRating = _userRepository.UserRatingIsNull(userRating, "movieId", "userName");

            Assert.That(userRating, Is.Not.Null);
            Assert.That(userRating.WatchedAmount, Is.EqualTo(0));
            Assert.That(userRating.LikesAmount, Is.EqualTo(0));
            Assert.That(userRating.DislikesAmount, Is.EqualTo(0));
            Assert.That(userRating.MovieId, Is.SameAs("movieId"));
            Assert.That(userRating.UserId, Is.SameAs("userName"));
        }

        private Mock<DbSet<UserRating>> SetUpUserRatings()
        {
            var sourceList = new List<UserRating>
            {
                new UserRating
                {
                    UserId = "1",
                    LikesAmount = 1,
                    DislikesAmount = 0,
                    MovieId = "1",
                    WatchedAmount = 1
                },
                new UserRating
                {
                    UserId= "2",
                    LikesAmount = 1,
                    DislikesAmount = 0,
                    MovieId = "1",
                    WatchedAmount = 1
                },
                new UserRating
                {
                    UserId = "1",
                    LikesAmount = 0,
                    DislikesAmount = 1,
                    MovieId = "2",
                    WatchedAmount = 1
                },
                new UserRating
                {
                    UserId = "2",
                    LikesAmount = 0,
                    DislikesAmount = 1,
                    MovieId = "2",
                    WatchedAmount = 1
                }
            };
            var queryable = sourceList.AsQueryable();
            var eventsDbSet = new Mock<DbSet<UserRating>>();
            eventsDbSet.As<IQueryable<UserRating>>().Setup(m => m.Provider).Returns(queryable.Provider);
            eventsDbSet.As<IQueryable<UserRating>>().Setup(m => m.Expression).Returns(queryable.Expression);
            eventsDbSet.As<IQueryable<UserRating>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            eventsDbSet.As<IQueryable<UserRating>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            eventsDbSet.Setup(d => d.Add(It.IsAny<UserRating>())).Callback<UserRating>((s) => sourceList.Add(s));
            return eventsDbSet;
        }
    }
}
