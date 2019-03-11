using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaHub_MVC.Models
{
    public class Contact
    {
        public string UserID { get; set; }
        public int ContactID { get; set; }

        public ApplicationUser User;
    }
}
