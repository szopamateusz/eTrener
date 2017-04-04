using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using eTrener.Models;
using eTrener.Migrations;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace eTrener.DAL
{
    public class eTrenerInitializer : MigrateDatabaseToLatestVersion<eTrenerContext, Configuration>
    {
        public static void SeedKursyData(eTrenerContext context)
        {
            var product = new List<ProductModel>
            {
                 new ProductModel() {ProductId = 1,Name = "Pierś z kurczaka",Calories = 100,Fat = 6,SaturatedFattyAcids = 2,Carbs = 20,Sugar = 0,Fiber = 10,Protein = 12,Salt = 2}

            };
            product.ForEach(k=>context.Products.AddOrUpdate(k));
            context.SaveChanges();
        }
    }
}