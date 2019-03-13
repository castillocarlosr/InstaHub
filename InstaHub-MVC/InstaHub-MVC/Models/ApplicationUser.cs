using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InstaHub_MVC.Models
{
    public class ApplicationUser
    {
        [Key]
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }

        public ICollection<Group> Groups;

    }
}
