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
        public int TrainingId { get; set; }
        public int ExcerciseId { get; set; }
        public int SeriesNumber { get; set; }
        public int Repetition { get; set; }
        public double Weight { get; set; }

        public virtual Excercise Excercise { get; set; }
        public virtual TrainigLog Log { get; set; }

    }
}