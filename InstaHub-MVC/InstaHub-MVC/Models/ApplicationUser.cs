using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InstaHub_MVC.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public bool Online { get; set; }
        public ClaimsIdentity Email { get; internal set; }

        public ICollection<Contact> Contacts;
        public ICollection<Message> Messages;
        public ICollection<Hub> Hubs;

    }

    public static class ApplicationRoles
    {
        public const string Member = "Member";
    }
}
