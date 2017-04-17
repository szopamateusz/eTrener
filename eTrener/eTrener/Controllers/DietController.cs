using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eTrener.DAL;
using eTrener.Infrastructure;
using eTrener.Models;

namespace eTrener.Controllers
{
    public class DietController : Controller
    {
       
        private eTrenerContext db;
        private ISessionMenager SessionMenager { get; set; }
        private AddMealMenager mealMenager;

        public DietController(eTrenerContext context, ISessionMenager sessionMenager)
        {
            this.db = context;
            this.SessionMenager = sessionMenager;
            mealMenager = new AddMealMenager(sessionMenager, db);
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
                Carbs = model.Carbs,
                Fat = model.Fat
            };
            db.Products.Add(models);
            db.SaveChanges();
            return RedirectToAction("AddProduct", "Diet");
        }

        public ActionResult ProductList(string searchQuery = null)
        {
            List<ProductModel> productList;
          //  ICacheProvider cache = new CacheProvider();
         //   if (cache.IsSet(Consts.ProductList))
         //   {
         //       productList = cache.Get(Consts.ProductList) as List<ProductModel>;
        //    }
        //    else
//{
                productList = db.Products.Where(a => (searchQuery == null
                ||a.Name.ToLower().Contains(searchQuery.ToLower())
                )).ToList();
            //      cache.Set(Consts.ProductList, productList, 10);
            //    }
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Products", productList);
            }
            return View(productList);
        }

        public ActionResult CreateDiet()
        {

            var meal = mealMenager.DownloadIngredient();
            CreateDietModel model = new CreateDietModel()
            {
                IngredientModels = meal
            };
            return View(model);
        }

        public ActionResult ProductHints(string term)
        {
            var productList =
                db.Products.Where(a => a.Name.ToLower().Contains(term.ToLower()))
                    .Take(5)
                    .Select(a => new {label = a.Name});
            return Json(productList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult select_food(string searchQuery = null)
        {
            List<ProductModel> productList;
            //  ICacheProvider cache = new CacheProvider();
            //   if (cache.IsSet(Consts.ProductList))
            //   {
            //       productList = cache.Get(Consts.ProductList) as List<ProductModel>;
            //    }
            //    else
            //{
            productList = db.Products.Where(a => (searchQuery == null
            || a.Name.ToLower().Contains(searchQuery.ToLower())
            )).ToList();
            //      cache.Set(Consts.ProductList, productList, 10);
            //    }
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Products", productList);
            }
            return View(productList);
           
        }
        [HttpPost]
        public ActionResult AddMeal(int id, SelectedFoodModel model)
        {
            decimal weight = model.Weight;
            string meal = model.Meal;
            mealMenager.AddMeal(id, weight, meal);
            return RedirectToAction("CreateDiet");
        }

        public ActionResult AddMeal(int id)
        {
            return View();
        }
        public ActionResult DeleteFromDiet(int ID)
        {
            mealMenager.DeleteFromDiet(ID);

            return RedirectToAction("CreateDiet");
        }
    }
}