using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using IssueTracker.Models;

namespace IssueTracker.DAL
{
    public class ProjectContext : DbContext
    {
        // public ProjectContext() calls parameterless class constructor by default // base("ProjectContext") is the database name
        // convention connections use SQL server express or LocalDB, to use anything else we must use connection string in web.config
        public ProjectContext() : base("IssueTrackerDB")
        { Database.SetInitializer<ProjectContext>(new DropCreateDatabaseIfModelChanges<ProjectContext>()); }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Sprint> Sprints { get; set; }

        // de-pluralizes table names ie. Issues -> Issue
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}