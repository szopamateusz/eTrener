using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eTrener.DAL;
using eTrener.Models;
using PagedList;

namespace eTrener.Controllers
{
    public class TrainingController : Controller
    {
        private eTrenerContext db = new eTrenerContext();

        // GET: Training
        public ActionResult AddTraining()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTraining(Excercise model)
        {
            Excercise models = new Excercise
            {
                ExcerciseId = model.ExcerciseId,
                Name = model.Name,
                About = model.About,
                BodyPart = model.BodyPart,
                YtUrl = model.YtUrl,
                ImgUrl = model.ImgUrl
            };
            db.Excercise.Add(models);
            db.SaveChanges();
            return RedirectToAction("AddTraining", "Training");
        }

        public ActionResult ExcerciseList(int? page,string query)
        {
            var excerciseList = db.Excercise.Where(a => (query == null|| a.Name.ToLower().Contains(query.ToLower()))).ToList();
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Excercise", excerciseList.ToPagedList(pageNumber, pageSize));
            }
            return View(excerciseList.ToPagedList(pageNumber,pageSize));
        }

        public ActionResult ProductHints(string term)
        {
            var productList =
                db.Products.Where(a => a.Name.ToLower().Contains(term.ToLower()))
                    .Take(5)
                    .Select(a => new {label = a.Name});
            return Json(productList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Popup(int id)
        {
            var excercise = db.Excercise.Where(m=>m.ExcerciseId==id).FirstOrDefault();
            return PartialView(excercise);
        }


        public ActionResult DeleteExcercise(int id=0)
        {
            var excerciseToDell = db.Excercise.Find(id);
            if (excerciseToDell == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.Excercise.Remove(excerciseToDell);
                db.SaveChanges();
            }
           return RedirectToAction("ExcerciseList");
        }
    }
}