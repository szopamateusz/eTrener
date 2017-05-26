using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eTrener.Models
{
    public class CreateDietModel
    {
        public List<IngredientModel> IngredientModels { get; set; }
        public decimal Calories { get; set; }
        public decimal Carbs { get; set; }
        public decimal Fat { get; set; }
        public decimal Protein { get; set; }


    }
}