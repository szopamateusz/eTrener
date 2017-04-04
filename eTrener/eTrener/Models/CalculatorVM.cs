using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eTrener.Models
{
    public class BMIViewModel
    {
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Solution { get; set; }
    }

    public class WHRViewModel
    {
        public string Sex { get; set; }
        public double WaistCircumference { get; set; }
        public double HipCircumference { get; set; }
    }

    public class SBWViewModel
    {
        public string Sex { get; set; }
        public double Height { get; set; }
    }

    public class BMViewModel
    {
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
    }

    public class PBFViewModel
    {
        public string Sex { get; set; }
        public double Waist { get; set; }
        public double Weight { get; set; }
    }
}