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

     
        
        public DbSet<DietViewModel> Diets { get; set; }
        public DbSet<DietPosition> Position { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<TrainigLog> TrainigLogs { get; set; }
        public DbSet<TrainingExcercise> Excercises { get; set; }
        public DbSet<Excercise> Excercise { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }
    }
}