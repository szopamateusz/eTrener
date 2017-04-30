using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eTrener.Models
{
    public class Excercise
    {
        [Key]
        public int ExcerciseId { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string BodyPart { get; set; }
        public string YtUrl { get; set; }
        public string ImgUrl { get; set; }
    }
}