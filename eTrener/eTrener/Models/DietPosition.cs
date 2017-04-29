using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eTrener.Models
{
    public class DietPosition
    {
        public int DietPositionId { get; set; }
        public int DietId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual DietModel diet { get; set; }
        public virtual ProductModel product { get; set; }
    }
}