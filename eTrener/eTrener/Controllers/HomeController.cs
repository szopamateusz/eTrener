﻿using System.Web.Mvc;

namespace eTrener.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MainPage(string nazwa)
        {
            return View(nazwa);
        }
    }
}