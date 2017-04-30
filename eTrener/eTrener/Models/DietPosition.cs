using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eTrener.Models
{
    public class DietPosition
    {
        [Key]
        public int DietPositionId { get; set; }
        public int DietId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual DietViewModel DietView { get; set; }
        public virtual Product product { get; set; }
    }
}