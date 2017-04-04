using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eTrener.Models
{
    public class IngredientModel
    {
        [Key]
        public int IngredientId { get; set; }
        public int ProductId { get; set; }
        public double Weight { get; set; }

        public virtual ProductModel Product { get; set; }

    }
}