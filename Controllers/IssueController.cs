using IssueTracker.DAL;
using IssueTracker.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace IssueTracker.Controllers
{
    public class IssueController : Controller
    {
        // GET: /Issue/Retrieve
        public ActionResult Index()
        {
            var context = new ProjectContext();
            return View(context.Issues.ToList());
        }

        public ActionResult Retrieve(int? id)
        {
            var context = new ProjectContext();

            // Handle index/view-all by using the nullable null id case:
            if (id == null) { return View(context.Issues.ToList()); }
            // Handle specific issue retrieval
            Issue issue = context.Issues.Find(id);
            if (issue == null) { return HttpNotFound(); } // return HttpNotFound();
            return View("Index", new List<Issue> { issue });
        }

        // Post Edit
        //[HttpPost, ActionName("Edit")]
        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatePost(int? id)
        {
            if (id == null) { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }

            var context = new ProjectContext();
            var issueToUpdate = context.Issues.Find(id);
            if (TryUpdateModel(issueToUpdate, "", new string[] { "UserEntityId", "SprintId", "StartDate", "CompletionDate", "Name" }))
            {
                try
                {
                    context.SaveChanges();
                    return RedirectToAction("Retrieve", id);
                }
                catch
                {
                    ModelState.AddModelError("", "Unable to save");
                }
            }
            return View(issueToUpdate);
        }
        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id == null) { return View("Index"); } // TODO: return View("doesntexist");

            return RedirectToAction("Retrieve", id);
        }

        // HttpGet - apparently links that straight delete are bad security practices so instead
        // we use a HttpGet to return a Confirm Deletion View which then posts issueid to delete HttpPost actionresult
        [HttpGet]
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            //    var context = new ProjectContext();=
            if (id == null) { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }
            if (saveChangesError.GetValueOrDefault()) { ViewBag.ErrorMessage = "Delete failed."; }
            using (var context = new ProjectContext())
            {
                Issue issue = context.Issues.Find(id);
                if (issue == null) { return HttpNotFound(); }
                return View(issue);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                using (var context = new ProjectContext())
                {
                    Issue issue = context.Issues.Find(id);
                    context.Issues.Remove(issue);
                    context.SaveChanges();
                }
            }
            catch
            {
                return RedirectToAction("Delete", new { ID = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        //public ActionResult Retrieve()
        //{
        //    using (var context = new ProjectContext())
        //    { var Issuelist = context.Issues.ToList(); }
        //    return View();
        //}

        // GET: /Issue/Retrieve
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Issue/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Issue issue) // for extra security change this line to: public ActionResult Create([Bind(Include="UserEntityId", "SprintId")]Issue issue)
        {
            try
            //if (ModelState.IsValid)
            //{
            //    context.Issues.Add(issue);
            //    context.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            {
                using (ProjectContext context = new ProjectContext())
                {
                    context.Issues.Add(issue);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (DataException)
            {
                return View();
            }
        }
    }
}