using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IssueTracker.Models
{
    public class Sprint
    {
        public int SprintId { get; set; }
        public int IssueId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }

        //public virtual Issue Issue { get; set; }
        //public virtual User User { get; set; }
    }
}