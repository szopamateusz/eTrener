using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eTrener.Models
{
    public class TrainingExcerciseVM
    {
        public  List<TrainingExcercise> Excercises { get; set; }
        [NotMapped]
        public List<SelectListItem> TrainingTimeList { get; set; }
        public string Date { get; set; }
    }
}