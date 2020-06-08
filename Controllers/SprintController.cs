using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IssueTracker.Controllers
{
    public class SprintController : Controller
    {
        // GET: Sprint
        public ActionResult Retrieve()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}