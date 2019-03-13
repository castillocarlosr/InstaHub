using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaHub_MVC.Models
{
    public class UserGroup
    {
        public int UserID { get; set; }
        public int GroupID { get; set; }

        public ApplicationUser User;
        public Group Group;
    }
}
