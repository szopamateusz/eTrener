﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eTrener.DAL;
using eTrener.Models;

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