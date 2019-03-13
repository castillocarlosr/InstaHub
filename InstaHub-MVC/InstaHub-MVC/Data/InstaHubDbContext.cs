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
            builder.Entity<UserHubs>().HasKey(uh => new { uh.UserID, uh.HubID });
            builder.Entity<Contact>().HasKey(c => new { c.UserID, c.ContactID });
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Hub> Hubs { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserHubs> UserHubs { get; set; }
    }
}
