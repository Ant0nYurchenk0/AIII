using AIII.Controllers.Api;
using AIII.Models;
using AIII.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIII.Controllers
{
    public class CustomMovieController : Controller
    {
        private IAlllDbContext _context;
        private CustomMoviesAPIController _apiController;

        public CustomMovieController(IAlllDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewMovie()
        {
            return View("CustomMovieForm");
        }

        public ActionResult Edit(string id)
        {
            var customMovie = _context.CustomMovies.SingleOrDefault(m => m.Id == id);

            if (customMovie == null)
                return HttpNotFound();

            return View("CustomMovieForm", customMovie);
        }

        public ActionResult Delete(string id)
        {
            _apiController = new CustomMoviesAPIController(_context);

            _apiController.DeleteMovie(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Save(CustomMovie customMovie)
        {
            if(!ModelState.IsValid)
                return View("CustomMovieForm", customMovie);

            if (customMovie.Id == null)
            {
                customMovie.Id = CustomMovieRepository.GetId();
                _context.CustomMovies.Add(customMovie);
            }
            else
            {
                var customMovieInDb = _context.CustomMovies.Single(m => m.Id == customMovie.Id);

                Mapper.Map(customMovie, customMovieInDb);
            }

            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}