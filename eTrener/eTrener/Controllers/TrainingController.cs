using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eTrener.DAL;
using eTrener.Models;

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

        public ActionResult ExcerciseList(string query)
        {
            var excerciseList = db.Excercise.Where(a => (query == null|| a.Name.ToLower().Contains(query.ToLower()))).ToList();

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Excercise", excerciseList);
            }
            return View(excerciseList);
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
    }
}