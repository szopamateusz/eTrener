using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using eTrener.DAL;
using eTrener.Models;

namespace eTrener.Infrastructure
{
    public class AddMealMenager
    {
        private eTrenerContext db;
        private ISessionMenager session;

        public AddMealMenager(ISessionMenager session, eTrenerContext db)
        {
            this.session = session;
            this.db = db;
        }

        public List<IngredientModel> DownloadIngredient()
        {
            List<IngredientModel> ingredient;

            if (session.Get<List<IngredientModel>>(Consts.MealKey) == null)
            {
                ingredient = new List<IngredientModel>();
            }
            else
            {
                ingredient = session.Get<List<IngredientModel>>(Consts.MealKey) as List<IngredientModel>;
            }

            return ingredient;
        }
       // , decimal weight, string units, string meal
        public void AddMeal(int productId, int weight, string meal)
        {
            var ingredient = DownloadIngredient();
            var addingMeal = db.Products.Where(k => k.ProductId == productId).SingleOrDefault();
            if (addingMeal != null)
            {
                var newMeal = new IngredientModel()
                {
                    Model = addingMeal,
                    Weight = weight,
                    Meal = meal
                };
                ingredient.Add(newMeal);
            }

            session.Set(Consts.MealKey, ingredient);
        }

        public int DeleteFromDiet(int productId,string meal)
        {
            var ingredient = DownloadIngredient();
            var dellMeal = ingredient.Find(k => k.Model.ProductId == productId&&k.Meal.Equals(meal));

            if (dellMeal != null)
            {
                ingredient.Remove(dellMeal);
            }
            return 0;

        }

        public decimal DownloadCalories()
        {
            var ingredient = DownloadIngredient();
            return ingredient.Sum(k => (k.Model.Calories * k.Weight/100));
        }

        public decimal DownloadCarbs()
        {
            var ingredient = DownloadIngredient();
            var result= ingredient.Sum(k => (k.Model.Carbs * k.Weight/100));
            return result;
        }

        public decimal DownloadFat()
        {
            var ingredient = DownloadIngredient();
            return ingredient.Sum(k => (k.Model.Fat * k.Weight/100));
        }
        public decimal DownloadProteins()
        {
            var ingredient = DownloadIngredient();
            return ingredient.Sum(k => (k.Model.Protein * k.Weight/100));
        }
        public DietViewModel CreateDiet(DietViewModel newDiet, string userId)
        {
            var diet = DownloadIngredient();
            newDiet.UserId = userId;


            if (newDiet.Diet == null)
                newDiet.Diet = new List<DietPosition>();

            int lastId = db.Diets.Max(k => k.DietId);
            foreach (var meal in diet)
            {

                var newPosition = new DietPosition()
                {
                    ProductId = meal.Model.ProductId,
                    Quantity = meal.Weight, 
                    DietId = newDiet.DietId
                };

                newDiet.Diet.Add(newPosition);
            }
            db.Diets.Add(newDiet);

            db.SaveChanges();

            return newDiet;
        }

        public void DeleteAll()
        {
            session.Set<List<IngredientModel>>(Consts.MealKey, null);
        }
    }
}