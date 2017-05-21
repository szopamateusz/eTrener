using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eTrener.Models
{
    public class TrainingExcercise
    {
        [Key]
        public int TrainingElementId { get; set; }

        [NotMapped]
        public List<SelectListItem> TrainingTimeList { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime TrainingTime { get; set; }

        public string ExcerciseName { get; set; }

        [NotMapped]
        public List<SelectListItem> ExcerciseNames { get; set; }

        public int SeriesNumber { get; set; }
        public int Repetition { get; set; }
        public double Weight { get; set; }
        public string UserId { get; set; }
        public virtual IdentityModels.ApplicationUser User { get; set; }
    }
}