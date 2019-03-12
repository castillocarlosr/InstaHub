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
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Online { get; set; }

        public ICollection<Contact> Contacts;
        public ICollection<Message> Messages;
        public ICollection<Hub> Hubs;

    }
}
