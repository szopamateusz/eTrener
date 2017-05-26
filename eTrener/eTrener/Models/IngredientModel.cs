using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security;

namespace eTrener.Models
{
    public class IngredientModel
    {
        [Key]
        public int IngredientId { get; set; }
        public Product Model { get; set; }
        public int Weight { get; set; }
        public string Meal { get; set; }
        public decimal RemaindingCalories { get; set; }
        public decimal RemaindingCarbs { get; set; }
        public decimal RemaindingFat { get; set; }
        public decimal RemaindingProtein { get; set; }
        //public string UserId { get; set; }
        //public virtual IdentityModels.ApplicationUser User { get; set; }

    }
}