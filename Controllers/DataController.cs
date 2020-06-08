using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IssueTracker.Controllers
{
    public class DataController : Controller
    {
        // GET: Data
        public ActionResult Report()
        {
            return View();
        }

        public ActionResult Analytics()
        {
            return View();
        }

        public ActionResult Export()
        {
            return View();
        }
    }
}