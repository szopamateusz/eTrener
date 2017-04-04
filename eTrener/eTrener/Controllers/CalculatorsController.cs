using System;
using System.Collections.Generic;
using System.Drawing;
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
            double solution = weight / Math.Pow(model.Height / 100, 2);
            ViewBag.solution = string.Format("Your BMI is {0}", solution.ToString("F"));
            if (solution < 18.5)
            {
                double correctWeight = 18.5 * Math.Pow(model.Height / 100, 2);
                ViewBag.correct = string.Format("Your correct body weight is {0} kg.", correctWeight.ToString("F"));
            }
            else if (solution < 25)
            {
                ViewBag.correct = string.Format("Your  body weight is correct.");
            }
            else
            {
                double correctWeight = 25 * Math.Pow(model.Weight / 100, 2);
                ViewBag.correct = string.Format("Your  body weight is too high. You should lose {0} kg.",
                    correctWeight.ToString("F"));
            }
            return View();
        }

        public ActionResult BM()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BM(BMViewModel model)
        {
            double weight = model.Weight;
            double height = model.Height;
            int age = model.Age;
            string sex = model.Sex;
            double maleresult = 66.47 + 13.75 * weight + 5.033 * height - 6.75 * age;
            double femaleresult = 655.09 + 9.56 * weight + 1.84 * height - 4.67 * age;
            if (sex.Equals("Male"))
            {
                ViewBag.result = string.Format("Your Basic Metabolic Rate is {0} kca", maleresult);
            }
            else
            {
                ViewBag.result = string.Format("Your Basic Metabolic Rate is {0} kca", femaleresult);
            }
            return View();
        }

        public ActionResult PBF()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PBF(PBFViewModel model)
        {
            double weight = model.Weight;
            double waist = model.Waist;
            string sex = model.Sex;
            double manPBF = ((1.634 * waist - 0.1804 * weight - 98.42) / 2.2 * weight) * 100;
            double womanPBF = ((1.634 * waist - 0.1804 * weight - 76.76) / 2.2 * weight)*100;
            if (sex.Equals("Male"))
            {
                ViewBag.result = string.Format("The body fat is about {0} %", manPBF);
            }
            else
            {
                ViewBag.result = string.Format("The body fat is about {0} %", womanPBF);

            }

            return View();
        }

        public ActionResult SBW()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SBW(SBWViewModel model)
        {
            double height = model.Height;
            string sex = model.Sex;
            double resultmale = height - 100 - ((height - 150) / 4);
            double resultmfemale = height - 100 - ((height - 150) / 2);
            if (sex.Equals("Male"))
            {
                ViewBag.result = string.Format("Your correct body weight is {0}", resultmale);
            }
            else
            {
                ViewBag.result = string.Format("Your correct body weight is {0} kg", resultmfemale);
            }
            return View();
        }

        public ActionResult WHR()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WHR(WHRViewModel model)
        {
            double hip = model.HipCircumference;
            double waist = model.WaistCircumference;
            string sex = model.Sex;
            double result = waist / hip;
            ViewBag.whr = string.Format("WHR:{0}", result);
            if (sex.Equals("Male") && result < 1 || sex.Equals("Female") && result < 0.8)
            {
                ViewBag.result = string.Format("You have an apple-like figure");
            }
            else
            {
                ViewBag.result = string.Format("You have an pear-like figure");
            }
            return View();
        }
    }
}