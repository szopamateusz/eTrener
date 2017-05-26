using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClosedXML.Excel;
using eTrener.DAL;
using eTrener.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using Microsoft.AspNet.Identity;
using PagedList;

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

        public ActionResult ShowLog(int?page)
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
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(trainingExcercises.ToPagedList(pageNumber,pageSize));
        }

        public ActionResult DeleteLog(int id = 0)
        {
            var logToDell = db.Excercises.Find(id);
            if (logToDell == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.Excercises.Remove(logToDell);
                db.SaveChanges();
            }
            return RedirectToAction("ShowLog");
        }

        [HttpPost]
        [ValidateInput(false)]
        public FileResult Export()
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
                trainingExcercises = db.Excercises.Where(o => o.UserId == userId).OrderByDescending(o => o.TrainingTime)
                    .ToArray();
            }
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[5]
            {
                new DataColumn("Training date"),
                new DataColumn("Excercise name"),
                new DataColumn("Series number"),
                new DataColumn("Repetition "),
                new DataColumn("Weight")
            });
            foreach (var excercise in trainingExcercises)
            {
                dt.Rows.Add(excercise.TrainingTime, excercise.ExcerciseName, excercise.SeriesNumber,
                    excercise.Repetition,
                    excercise.Weight);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Grid.xlsx");
                }
            }
        }
    }
}