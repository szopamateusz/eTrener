using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eTrener.DAL;
using eTrener.Models;

namespace eTrener.Controllers
{
    public class DietController : Controller
    {
        private eTrenerContext db= new eTrenerContext();
        // GET: Diet
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(ProductModel model)
        {

            ProductModel models = new ProductModel
            {
                ProductId = model.ProductId,
                Name = model.Name,
                Calories = model.Calories,
                Protein = model.Protein,
                Sugar = model.Sugar,
                Carbs = model.Carbs,
                Salt = model.Salt,
                Fiber = model.Fiber,
                Fat = model.Fat,
                SaturatedFattyAcids = model.SaturatedFattyAcids
            };
            db.Products.Add(models);
            db.SaveChanges();
            return View(model);
        }
    }
}