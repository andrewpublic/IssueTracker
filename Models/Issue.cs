using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace IssueTracker.Models
{
    public class Issue
    {
        public int IssueId { get; set; }
        public int UserId { get; set; }
        public int SprintId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }

        //public virtual User User { get; set; }
        //public virtual Sprint Sprint { get; set; }
    }
}