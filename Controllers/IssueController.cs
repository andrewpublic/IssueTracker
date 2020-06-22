using IssueTracker.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IssueTracker.Controllers
{
    public class IssueController : Controller
    {
        // GET: Issue
        public ActionResult Retrieve()
        {
            var context = new ProjectContext();
            return View(context.Issues.ToList());
        }

        //public ActionResult Retrieve()
        //{
        //    using (var context = new ProjectContext())
        //    { var Issuelist = context.Issues.ToList(); }
        //    return View();
        //}

        public ActionResult Create()
        {
            return View();
        }
    }
}