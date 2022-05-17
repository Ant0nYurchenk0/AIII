using AIII.Controllers.Api;
using AIII.Repositories;
using AIII.ViewModels;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using AIII.Models;
using AutoMapper;

namespace AIII.Controllers
{
    public class HomeController : Controller
    {
        IImdbApiController _imdbApi;
        CustomMoviesAPIController _customApi;
        ApplicationDbContext _context;
        public HomeController()
        {
            _imdbApi = new ImdbApiController();
            _customApi = new CustomMoviesAPIController();
        }

        public ActionResult Index()
        {
            var movies = new HomeMovies();
            movies.PopularMovies = _imdbApi.GetPopularMovies().Take(10).ToList();
            movies.PopularTVs = _imdbApi.GetPopularTVs().Take(10).ToList();
            movies.CustomMovies = _customApi.GetShortInfoMovies().Take(10).ToList();
            return View(movies);
        }

        public ActionResult About()
        {
            _context = new ApplicationDbContext();

            var teamMembers = _context.TeamMembers.ToList();

            if (User.IsInRole("Admin") || User.IsInRole("Moderator"))
                return View(teamMembers);
            else
                return View("ReadOnlyAbout", teamMembers);
        }

        public ActionResult EditAbout(int id)
        {
            _context = new ApplicationDbContext();

            var teamMember = _context.TeamMembers.FirstOrDefault(m => m.Id == id);

            return View(teamMember);
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Save(TeamMember teamMember)
        {
            if (!ModelState.IsValid)
                return View("EditAbout", teamMember);

            _context = new ApplicationDbContext();
            var teamMemberInDb = _context.TeamMembers.Single(m => m.Id == teamMember.Id);
            Mapper.Map(teamMember, teamMemberInDb);

            _context.SaveChanges();
            return RedirectToAction("About");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ShowImdbMovie(string id)
        {
            return View();
        }
    }
}