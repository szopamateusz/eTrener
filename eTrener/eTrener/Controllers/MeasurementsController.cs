using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eTrener.DAL;
using eTrener.Models;
using Microsoft.AspNet.Identity;
using PagedList;

namespace eTrener.Controllers
{
    public class MeasurementsController : Controller
    {
        private eTrenerContext db = new eTrenerContext();

        // GET: Measurements
        public ActionResult AddMeasurements()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddMeasurements(BodyMeasurements model)
        {
            var userId = User.Identity.GetUserId();
            try
            {
                BodyMeasurements measurements = new BodyMeasurements()
                {
                    BodyMeasurementdId = model.BodyMeasurementdId,
                    TrainingTime = model.TrainingTime,
                    Weight = model.Weight,
                    UserId = userId,
                    Biceps = model.Biceps,
                    Calf = model.Calf,
                    Chest = model.Chest,
                    Forearm = model.Forearm,
                    Hip = model.Hip,
                    Neck = model.Neck,
                    Thigh = model.Thigh,
                    Waist = model.Waist,
                    Wrist = model.Wrist
                };
                db.BodyMeasurementses.Add(measurements);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                ViewBag.Error = "Incorrect data";
            }

            return RedirectToAction("AddMeasurements", "Measurements");
        }
        public ActionResult ShowMeasurements(int? page)
        {
            bool isAdmin = User.IsInRole("Admin");
            IEnumerable<BodyMeasurements> bodyMeasurementses;
            if (isAdmin)
            {
                bodyMeasurementses = db.BodyMeasurementses.OrderByDescending(o => o.TrainingTime).ToArray();
            }
            else
            {
                var userId = User.Identity.GetUserId();
                bodyMeasurementses = db.BodyMeasurementses.Where(o => o.UserId == userId).OrderByDescending(o => o.TrainingTime).ToArray();
            }
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(bodyMeasurementses.ToPagedList(pageNumber,pageSize));
      
        }

        public ActionResult DeleteMeasurement(int id = 0)
        {
            var measurementToDell = db.BodyMeasurementses.Find(id);
            if (measurementToDell == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.BodyMeasurementses.Remove(measurementToDell);
                db.SaveChanges();
            }
            return RedirectToAction("ShowMeasurements");
        }
    }
}