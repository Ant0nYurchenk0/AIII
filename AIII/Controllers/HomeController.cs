﻿using AIII.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIII.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var repo = new ImdbRepository();
            var obj = repo.SearchById("tt1375666");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
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