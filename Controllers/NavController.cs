using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IssueTracker.Controllers
{
    public class NavController : Controller
    {
        // GET: Nav
        public ActionResult Settings()
        {
            return View();
        }

        public ActionResult UserProfile()
        {
            return View();
        }

        public ActionResult Logout()
        {
            return View();
        }
    }
}