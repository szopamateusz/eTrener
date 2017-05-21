using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eTrener.Models
{
    public class BodyMeasurements
    {
        [Key]
        public int BodyMeasurementdId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of measurement")]
        public DateTime TrainingTime { get; set; }

        [Display(Name = "Your weight")]
        public string Weight { get; set; }

        [Display(Name = "Your neck circuit")]
        public string Neck { get; set; }

        [Display(Name = "Your chest circuit")]
        public string Chest { get; set; }

        [Display(Name = "Your biceps circuit")]
        public string Biceps { get; set; }


        [Display(Name = "Your forearm circuit")]
        public string Forearm { get; set; }

        [Display(Name = "Your waist circuit")]
        public string Waist { get; set; }

        [Display(Name = "Your hip circuit")]
        public string Hip { get; set; }

        [Display(Name = "Your wrist circuit")]
        public string Wrist { get; set; }

        [Display(Name = "Your thigh circuit")]
        public string Thigh { get; set; }

        [Display(Name = "Your calf circuit")]
        public string Calf { get; set; }

        public string UserId { get; set; }
        public virtual IdentityModels.ApplicationUser User { get; set; }
    }
}