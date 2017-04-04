using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eTrener.Models
{
    public class MealModel
    {
        [Key]
        public int MealId { get; set; }
        public string Name { get; set; }
        public List<IngredientModel> Products { get; set; }
        public virtual DietModel Diet { get; set; }
    }
}