using InstaHub_MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaHub_MVC.Models.Interfaces
{
    public interface IAppUser
    {
        Task AddAppUser(ApplicationUser AppUser);
        Task<ApplicationUser> GetApplicationUserByID(string email);
    }
}
