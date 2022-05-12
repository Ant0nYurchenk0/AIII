﻿using AIII.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIII.Controllers
{
    public class CustomMovieController : Controller
    {
        public ApplicationDbContext _context;

        public CustomMovieController()
        {
            _context = new ApplicationDbContext();
        }


        // GET: Movies
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewMovie()
        {
            return View("CustomMovieForm");
        }

        public ActionResult Edit(int id)
        {
            var customMovie = _context.CustomMovies.SingleOrDefault(m => m.MovieId == id);

            if (customMovie == null)
                return HttpNotFound();

            return View("CustomMovieForm", customMovie);
        }

        [HttpPost]
        public ActionResult Save(CustomMovie customMovie)
        {
            if(!ModelState.IsValid)
                return View("CustomMovieForm", customMovie);

            if(customMovie.MovieId == 0)
                _context.CustomMovies.Add(customMovie);
            else
            {
                var customMovieInDb = _context.CustomMovies.Single(m => m.MovieId == customMovie.MovieId);

                Mapper.Map(customMovie, customMovieInDb);
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}