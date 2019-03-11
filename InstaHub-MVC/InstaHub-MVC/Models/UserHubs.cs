using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaHub_MVC.Models
{
    public class UserHubs
    {
        public string UserID { get; set; }
        public int HubID { get; set; }

        public ApplicationUser User;
        public Hub Hub;
    }
}
