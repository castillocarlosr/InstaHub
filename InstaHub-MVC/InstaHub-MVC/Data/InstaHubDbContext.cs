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



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserGroup>().HasKey(ug => new { ug.UserID, ug.GroupID });

            builder.Entity<Group>().HasData(
                new Group
                {
                    ID = 1,
                    Name = "Code-R-Us",
                    GroupType = GroupType.Public
                },
                new Group
                {
                    ID = 2,
                    Name = "Public Code",
                    GroupType = GroupType.Public
                });
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
    }
}
