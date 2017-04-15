using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using eTrener.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace eTrener.DAL
{
    public class eTrenerContext : IdentityDbContext<IdentityModels.ApplicationUser>
    {
        public eTrenerContext() : base("eTrener")
        {
        }
        static eTrenerContext()
        {
            Database.SetInitializer <eTrenerContext>(new eTrenerInitializer());
        }
        public static eTrenerContext Create()
        {
            return new eTrenerContext();
        }

     
        
        public DbSet<DietModel> Diets { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }
    }
}