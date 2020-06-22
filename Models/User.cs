using IssueTracker.Controllers;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace IssueTracker.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public DateTime SignUpDate { get; set; }
        // ActiveIssues
        // ActiveSprints

        // Lazy loading = virtual keyword (this section is navigation?)
        public virtual ICollection<Issue> Issues { get; set; }
        public virtual ICollection<Sprint> Sprints { get; set; }
    }
}