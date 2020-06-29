using IssueTracker.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IssueTracker.Controllers
{
    public class SprintController : Controller
    {
        public ActionResult Index()
        {
            var context = new ProjectContext();
            return View(context.Sprints.ToList());
        }

        // GET: Sprint
        public ActionResult Retrieve()
        {
            var context = new ProjectContext();
            return View(context.Sprints.ToList());
        }



        public ActionResult Create()
        {
            return View();
        }
    }
}