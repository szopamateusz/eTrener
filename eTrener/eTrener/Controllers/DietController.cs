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
                Carbs = model.Carbs,
                Fat = model.Fat
            };
            db.Products.Add(models);
            db.SaveChanges();
            return RedirectToAction("AddProduct", "Diet");
        }
        public ActionResult ProductList()
        {
            var list = db.Products.ToList();
            return View(list);
        }

    }

}