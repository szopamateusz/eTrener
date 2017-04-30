using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using eTrener.DAL;
using eTrener.Infrastructure;
using eTrener.Models;
using eTrener.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

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
        public ActionResult AddProduct(Product model)
        {
            Product models = new Product
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
            List<Product> productList;
            //  ICacheProvider cache = new CacheProvider();
            //   if (cache.IsSet(Consts.ProductList))
            //   {
            //       productList = cache.Get(Consts.ProductList) as List<Product>;
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

        public ActionResult CreateDiet()
        {
            var meal = mealMenager.DownloadIngredient();
            var calories = mealMenager.DownloadCalories();
            var carbs = mealMenager.DownloadCarbs();
            var fat = mealMenager.DownloadFat();
            var protein = mealMenager.DownloadProteins();
            CreateDietModel model = new CreateDietModel()
            {
                IngredientModels = meal,
                Calories = calories,
                Carbs = carbs,
                Fat = fat,
                Protein = protein
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
            List<Product> productList;
            //  ICacheProvider cache = new CacheProvider();
            //   if (cache.IsSet(Consts.ProductList))
            //   {
            //       productList = cache.Get(Consts.ProductList) as List<Product>;
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
            var weight = model.Weight;
            string meal = model.Meal;
            mealMenager.AddMeal(id, weight, meal);
            return RedirectToAction("CreateDiet");
        }

        public ActionResult AddMeal(int id)
        {
            return View();
        }

        public ActionResult DeleteFromDiet(int ID, string meal)
        {
            mealMenager.DeleteFromDiet(ID, meal);
            var calories = mealMenager.DownloadCalories();
            var carbs = mealMenager.DownloadCarbs();
            var fat = mealMenager.DownloadFat();
            var protein = mealMenager.DownloadProteins();
            var result = new DeleteProductFromListModel()
            {
                Calories = calories,
                Carbs = carbs,
                Fat = fat,
                Protein = protein
            };
            return Json(result);
        }
        public ActionResult Create(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(DietViewModel details)
        {
            var userId = User.Identity.GetUserId();

            var newOrder = mealMenager.CreateDiet(details, userId);
            mealMenager.DeleteAll();


            return RedirectToAction("CreateDiet");
        }
    }
}