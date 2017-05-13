using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eTrener.Models
{
    public class TrainingExcercise
    {
        [Key]
        public int TrainingElementId { get; set; }
        public DateTime TrainingTime { get; set; }
        public string ExcerciseName { get; set; }
        public int SeriesNumber { get; set; }
        public int Repetition { get; set; }
        public double Weight { get; set; }
        public string UserId { get; set; }
        public virtual IdentityModels.ApplicationUser User { get; set; }
    }
}