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
            var product = new List<Product>
            {

            };
            product.ForEach(k=>context.Products.AddOrUpdate(k));
            context.SaveChanges();
        }
    }
}