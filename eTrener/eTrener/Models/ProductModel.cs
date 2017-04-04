using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eTrener.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Calories { get; set; }
        public double Fat { get; set; }
        public double SaturatedFattyAcids { get; set; }
        public double Carbs { get; set; }
        public double Sugar { get; set; }
        public double Fiber { get; set; }
        public double Protein { get; set; }
        public double Salt { get; set; }
      //  public virtual  MealModel   Meal { get; set; }
    }
}