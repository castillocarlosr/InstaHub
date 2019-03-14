using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InstaHub_MVC.Models
{
    public class ApplicationUser
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }

        public ICollection<Group> Groups;

    }
}
