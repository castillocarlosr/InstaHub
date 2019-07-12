using InstaHub_MVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaHub_MVC.Data
{
    public class InstaHubDbContext : DbContext
    {
        public InstaHubDbContext(DbContextOptions<InstaHubDbContext> options) : base(options)
        {

        }


        /// <summary>
        /// Populating the database with seeded data
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserGroup>().HasKey(ug => new { ug.UserID, ug.GroupID });
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
    }
}
