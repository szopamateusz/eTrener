﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eTrener.Models
{
    public class DietViewModel
    {
        [Key]
        public int DietId { get; set; }
        public string UserId { get; set; }
        public virtual IdentityModels.ApplicationUser User { get; set; }
        public List<DietPosition> Diet{ get; set; }
    }
}