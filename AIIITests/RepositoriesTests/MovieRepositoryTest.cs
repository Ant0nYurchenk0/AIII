using AIII.Dtos;
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
    public class MovieRepositoryTest
    {
        private ApplicationDbContext _context;
        MovieRepository _movieRepository;

        [SetUp]
        public void Setup()
        {
            var fakeDBContext = new Mock<ApplicationDbContext>();
            fakeDBContext.Object.MovieShortInfo = SetUpMovieShortInfo().Object;
            fakeDBContext.Object.CustomMovies = SetUpCustomMovies().Object;
            _context = fakeDBContext.Object;

            _movieRepository = new MovieRepository(_context);
        }

        [Test]
        public void GetMovieById_MovieShortInfoHasMovieId_ReturnMovieShortInfo()
        {
            var movieId = "1";

            var result = _movieRepository.GetMovieById(movieId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id == movieId && result.Title == "Title" && 
                result.Image == "Image" && result.ImdbRating == "ImdbRating");
        }

        [Test]
        public void GetMovieById_CustomMovieHasMovieId_ReturnMovieShortInfo()
        {
            var movieId = "2";

            var result = _movieRepository.GetMovieById(movieId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id == movieId && result.Title == "Title"
                && result.Image == "Image");
        }

        [Test]
        public void GetMovieById_CustomMovieAndMovieShortInfoDoNotHaveMovieId_ReturnNull()
        {
            var movieId = "3";

            var result = _movieRepository.GetMovieById(movieId);

            Assert.IsNull(result);
        }

        [Test]
        public void GetMoviesByIds_DbContextHasAllMoviesWithParametersIds_ReturnListOfMovieShortInfoWithTwoFilms()
        {
            var moviesIds = new List<string>() { "1", "2" };

            var result = _movieRepository.GetMoviesByIds(moviesIds);

            Assert.That(result!= null);
            Assert.That(result[0].Id == "1" &&
                result[0].Image == "Image" &&
                result[0].ImdbRating == "ImdbRating" &&
                result[0].Title == "Title" &&
                result[1].Id == "2" &&
                result[1].Title == "Title" &&
                result[1].Image == "Image"); ;
        }

        private Mock<DbSet<MovieShortInfo>> SetUpMovieShortInfo()
        {
            var sourceList = new List<MovieShortInfo>
            {
                new MovieShortInfo
                {
                    Id = "1",
                    Title = "Title",
                    Image = "Image",
                    ImdbRating = "ImdbRating"
                }
            };
            var queryable = sourceList.AsQueryable();
            var eventsDbSet = new Mock<DbSet<MovieShortInfo>>();
            eventsDbSet.As<IQueryable<MovieShortInfo>>().Setup(m => m.Provider).Returns(queryable.Provider);
            eventsDbSet.As<IQueryable<MovieShortInfo>>().Setup(m => m.Expression).Returns(queryable.Expression);
            eventsDbSet.As<IQueryable<MovieShortInfo>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            eventsDbSet.As<IQueryable<MovieShortInfo>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            eventsDbSet.Setup(d => d.Add(It.IsAny<MovieShortInfo>())).Callback<MovieShortInfo>((s) => sourceList.Add(s));
            return eventsDbSet;
        }

        private Mock<DbSet<CustomMovie>> SetUpCustomMovies()
        {
            var sourceList = new List<CustomMovie>
            {
                new CustomMovie
                {
                    Id = "2",
                    Title = "Title",
                    Image = "Image"
                }
            };
            var queryable = sourceList.AsQueryable();
            var eventsDbSet = new Mock<DbSet<CustomMovie>>();
            eventsDbSet.As<IQueryable<CustomMovie>>().Setup(m => m.Provider).Returns(queryable.Provider);
            eventsDbSet.As<IQueryable<CustomMovie>>().Setup(m => m.Expression).Returns(queryable.Expression);
            eventsDbSet.As<IQueryable<CustomMovie>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            eventsDbSet.As<IQueryable<CustomMovie>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            eventsDbSet.Setup(d => d.Add(It.IsAny<CustomMovie>())).Callback<CustomMovie>((s) => sourceList.Add(s));
            return eventsDbSet;
        }
    }
}
