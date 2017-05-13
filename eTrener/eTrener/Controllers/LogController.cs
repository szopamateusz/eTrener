using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eTrener.Controllers
{
    public class LogController : Controller
    {
        // GET: Log
        public ActionResult AddExcercise()
        {
            return View();
        }
    
        public ActionResult ShowLog()
        {
            return View();
        }
    }
}