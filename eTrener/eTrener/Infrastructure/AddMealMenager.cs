using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public void AddMeal(int productId, decimal weight, string meal)
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

        public int DeleteFromDiet(int productId)
        {
            var ingredient = DownloadIngredient();
            var dellMeal = ingredient.Find(k => k.Model.ProductId == productId);

            if (dellMeal != null)
            {
                ingredient.Remove(dellMeal);
            }

            return 0;
        }

        public decimal DownloadCalories()
        {
            var koszyk = DownloadIngredient();
            return koszyk.Sum(k => (k.Model.Calories * k.Weight));
        }

        public decimal DownloadCarbs()
        {
            var koszyk = DownloadIngredient();
            return koszyk.Sum(k => (k.Model.Carbs * k.Weight));
        }

        public decimal DownloadFat()
        {
            var koszyk = DownloadIngredient();
            return koszyk.Sum(k => (k.Model.Fat * k.Weight));
        }
        public decimal DownloadProteins()
        {
            var koszyk = DownloadIngredient();
            return koszyk.Sum(k => (k.Model.Protein * k.Weight));
        }
//        public DietModel UtworzZamowienie(DietModel newDiet, string userId)
//        {
//            var koszyk = PobierzKoszyk();
//            noweZamowienie.DataDodania = DateTime.Now;
//            noweZamowienie.UserId = userId;
//
//            db.Zamowienia.Add(noweZamowienie);
//
//            if (noweZamowienie.PozycjeZamowienia == null)
//                noweZamowienie.PozycjeZamowienia = new List<PozycjaZamowienia>();
//
//            decimal koszykWartosc = 0;
//
//            foreach (var koszykElement in koszyk)
//            {
//                var nowaPozycjaZamowienia = new PozycjaZamowienia()
//                {
//                    KursId = koszykElement.Kurs.KursId,
//                    Ilosc = koszykElement.Ilosc,
//                    CenaZakupu = koszykElement.Kurs.CenaKursu
//                };
//
//                koszykWartosc += (koszykElement.Ilosc * koszykElement.Kurs.CenaKursu);
//                noweZamowienie.PozycjeZamowienia.Add(nowaPozycjaZamowienia);
//            }
//
//            noweZamowienie.WartoscZamowienia = koszykWartosc;
//            db.SaveChanges();
//
//            return noweZamowienie;
//        }

        public void PustyKoszyk()
        {
            session.Set<List<IngredientModel>>(Consts.MealKey, null);
        }
    }
}