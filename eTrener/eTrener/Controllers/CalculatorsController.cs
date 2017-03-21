using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eTrener.Models;

namespace eTrener.Controllers
{
    public class CalculatorsController : Controller
    {
        // GET: Calculators
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BMI()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BMI(BMIViewModel model)
        {
            double weight = model.Weight;
            double height = model.Height;
            double solution = weight / height;
            ViewBag.solution = solution.ToString();

            
                return View();
        }

        public ActionResult BM()
        {
            return View();
        }

        public ActionResult PBF()
        {
            return View();
        }

        public ActionResult SBW()
        {
            return View();
        }

        public ActionResult WHR()
        {
            return View();
        }
    }
}