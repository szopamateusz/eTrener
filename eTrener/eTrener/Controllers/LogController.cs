using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eTrener.DAL;
using eTrener.Models;
using Microsoft.AspNet.Identity;

namespace eTrener.Controllers
{
    public class LogController : Controller
    {
        private eTrenerContext db = new eTrenerContext();

        // GET: Log
        public ActionResult AddExcercise()
        {
            IEnumerable<SelectListItem> items = db.Excercise.Select(c => new SelectListItem
            {
                Value = c.Name,
                Text = c.Name
            });
            ViewBag.Excercises = items;

            return View();
        }

        [HttpPost]
        public ActionResult AddExcercise(TrainingExcercise model)
        {
            var userId = User.Identity.GetUserId();
            TrainingExcercise excercise = new TrainingExcercise()
            {
                TrainingElementId = model.TrainingElementId,
                ExcerciseName = model.ExcerciseName,
                SeriesNumber = model.SeriesNumber,
                Repetition = model.Repetition,
                TrainingTime = model.TrainingTime,
                Weight = model.Weight,
                UserId = userId
            };
            db.Excercises.Add(excercise);
            db.SaveChanges();
            return RedirectToAction("AddExcercise", "Log");
        }

        public ActionResult ShowLog()
        {
            return View();
        }
    }
}