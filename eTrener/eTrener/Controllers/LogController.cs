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
            TrainingExcercise excercise = new TrainingExcercise();
            excercise.ExcerciseNames = Excercises();
            return View(excercise);
        }

        private static List<SelectListItem> Excercises()
        {
            eTrenerContext db=new eTrenerContext();
            List<SelectListItem> items = new List<SelectListItem>(db.Excercise.Select(c => new SelectListItem
            {
                Value = c.Name,
                Text = c.Name
            }));
            return items;
        }

            [HttpPost]
            public ActionResult AddExcercise(TrainingExcercise model)
            {

                var userId = User.Identity.GetUserId();
                try
                {
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
                
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Incorrect data";
                }

                return RedirectToAction("AddExcercise", "Log");
            }

        public ActionResult ShowLog()
        {
            bool isAdmin = User.IsInRole("Admin");
            IEnumerable<TrainingExcercise> trainingExcercises;
            if (isAdmin)
            {
                trainingExcercises = db.Excercises.OrderByDescending(o => o.TrainingTime).ToArray();
            }
            else
            {
                var userId = User.Identity.GetUserId();
                trainingExcercises = db.Excercises.Where(o => o.UserId == userId).OrderByDescending(o => o.TrainingTime).ToArray();
            }
            return View(trainingExcercises);
        }
    }
}