using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using eTrener.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace eTrener.DAL
{
    public class eTrenerContext:IdentityDbContext<IdentityModels.ApplicationUser>
    {
        public eTrenerContext():base("eTrener")
        {
           
        }

        public static eTrenerContext Create()
        {
            return new eTrenerContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }
    }
}