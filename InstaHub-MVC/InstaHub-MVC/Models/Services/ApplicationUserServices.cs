using InstaHub_MVC.Data;
using InstaHub_MVC.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaHub_MVC.Models.Services
{
    public class ApplicationUserServices : IAppUser
    {
        private InstaHubDbContext _context { get; }

        public ApplicationUserServices(InstaHubDbContext context)
        {
            _context = context;
        }

        public async Task AddAppUser(ApplicationUser appUser)
        {
            _context.ApplicationUsers.Add(appUser);
            await _context.SaveChangesAsync();
        }

        public async Task<ApplicationUser> GetApplicationUserByEmail(string email)
        {
            ApplicationUser applicationUser = await _context.ApplicationUsers.FirstOrDefaultAsync(u => u.Email == email);
            return applicationUser;
        }
    }
}
