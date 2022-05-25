using AIII.Constants;
using AIII.Controllers.Api;
using AIII.Dtos;
using AIII.Models;
using Microsoft.AspNet.Identity;

using AIII.Repositories;
using AIII.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AIII.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        private ApplicationDbContext _context;
        private IImdbApiController _api;
        private CustomMoviesAPIController _custom;
        private UserRatingAPIController _rating;
        private UserRatingRepository _repository;

        public SearchController(ApplicationDbContext context, IImdbApiController api, CustomMoviesAPIController custom, 
            UserRatingAPIController rating, UserRatingRepository repository)
        {
            _context = context;
            _api = api;
            _custom=custom;
            _rating=rating;
            _repository=repository;
        }

        public ActionResult GetByTag(string tag, int numberOfPages = 0, int currentPage = 1,  bool newRequest = false)
        {
            if (AllNulls(tag))
                return RedirectToAction("Index", "Home");
            if (currentPage < 0 || currentPage > numberOfPages)
                currentPage = 1;
            var result = new SearchResult();
            result.CurrentPage = currentPage;
            result.Tag = tag;
            var searchResult = SearchApi(tag);
            result.NumberOfPages = (int)Math.Ceiling(searchResult.Count / 12.0);
            result.Movies = searchResult.Skip(12 * (currentPage - 1)).Take(12).Select(m => Mapper.Map<MovieShortInfoDto>(m));
            return View("..\\Movies\\SearchResult", result);
        }

        private IQueryable<SearchInfo> FilterTag(IQueryable<SearchInfo> result, string tag)
        {
            if (tag != null)
                result = result.Where(m => m.Tag.Contains(tag));
            return result;
        }

        private List<MovieFullInfoDto> SearchApi(string tag)
        {
            var result = new List<MovieFullInfoDto>();
            switch (tag)
            {
                case "movies250":
                    result = _api.GetTopMovies();
                    break;
                case "tvs250":
                    result = _api.GetTopTVs();
                    break;
                case "popMov":
                    result = _api.GetPopularMovies();
                    break;
                case "popTV":
                    result = _api.GetPopularTVs();
                    break;
                case "custom":
                    result = _custom.GetMovies().ToList();
                    break;
                case "liked":
                    result = _rating.GetMostLiked().ToList();
                    break;
                case "watched":
                    result = _rating.GetMostWatched().ToList();
                    break;
                case "userLikes":
                    result = _repository.UserLikedMovies(User.Identity.GetUserName()).ToList();
                    break;
                case "userDislikes":
                    result = _repository.UserDislikedMovies(User.Identity.GetUserName()).ToList();
                    break;
                case "userWatched":
                    result = _repository.UserWatchedMovies(User.Identity.GetUserName()).ToList(); 
                    break;
                default: break;
            }
            
            return result;
        }

        public ActionResult Index(string title, List<string> genres, List<string> userRating,
            int numberOfPages = 0, int currentPage = 1, Sorting sorting = Sorting.Title, bool newRequest = false)
        {
            if (AllNulls(title, genres, userRating))
                return RedirectToAction("Index", "Home");
            if (currentPage < 0 || currentPage > numberOfPages)
                currentPage = 1;
            var result = new SearchResult();
            result.CurrentPage = currentPage;
            result.Sorting = sorting;
            result.Title = title;
            result.UserRating = userRating;
            result.Genres = genres;
            if (newRequest)
                SearchApi(title, genres, userRating);
            var searchResult = Search(title, genres, userRating, sorting);
            result.NumberOfPages = (int)Math.Ceiling(searchResult.Count / 12.0);
            result.Movies = searchResult.Skip(12 * (currentPage - 1)).Take(12);
            return View("..\\Movies\\SearchResult", result);
        }
        private void SearchApi(string title, List<string> genres, List<string> userRating)
        {
            var moviesShort = _api.Search(title, null, null, genres, null, userRating);
            foreach (var movie in moviesShort)
                if (!_context.SearchInfo.Any(m => m.Id == movie.Id))
                    _context.SearchInfo.Add(Mapper.Map<SearchInfo>(
                        Mapper.Map<SearchInfoDto>(movie)));
            _context.SaveChanges();
        }
        private bool AllNulls(params object[] parameters)
        {
            foreach (var item in parameters)
                if (item != null)
                    return false;
            return true;
        }
        private List<MovieShortInfoDto> Search(string title, List<string> genres, List<string> userRating, Sorting sorting)
        {
            var result = _context.SearchInfo.Select(m => m);
            result = FilterTitle(result, title);
            result = FilterGenres(result, genres);
            result = FilterRating(result, userRating);
            var resultList = Sort(result, sorting);

            var returnVal = new List<MovieShortInfoDto>();
            foreach (var movie in resultList)
                returnVal.Add(Mapper.Map<MovieShortInfoDto>(
                    Mapper.Map<SearchInfoDto>(movie)));
            return returnVal;

        }
        public List<SearchInfo> Sort(IQueryable<SearchInfo> result, Sorting sorting)
        {
            switch (sorting)
            {
                case Sorting.Rating:
                    return result.OrderByDescending(m => m.ImdbRating).ToList();
                case Sorting.Title:
                    return result.OrderBy(m => m.Title).ToList();
                default:
                    return result.ToList();
            }
        }
        private IQueryable<SearchInfo> FilterRating(IQueryable<SearchInfo> result, List<string> userRating)
        {
            if (userRating != null && userRating.Count > 0)
            {
                var doubleRating = userRating.Select(r => Convert.ToDouble(r)).OrderBy(r => r).ToArray();
                var minRating = doubleRating[0];
                var maxRating = doubleRating[1];
                if (minRating != 1)
                    result = result.Where(m => m.ImdbRating >= minRating);
                if (maxRating != 10)
                    result = result.Where(m => m.ImdbRating <= maxRating);
            }
            return result;
        }
        private IQueryable<SearchInfo> FilterGenres(IQueryable<SearchInfo> result, List<string> genres)
        {
            if (genres != null && genres.Count > 0)
                foreach (var genre in genres)
                    result = result.Where(m => m.Genres.Contains(genre));
            return result;
        }
        private IQueryable<SearchInfo> FilterTitle(IQueryable<SearchInfo> result, string title)
        {
            if (title != null)
                result = result.Where(m => m.Title.Contains(title));
            return result;
        }
    }
}