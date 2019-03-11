using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaHub_MVC.Models
{
    public class Hub
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public HubType HubType { get; set; }

        public ICollection<Message> Messages;
        public ICollection<ApplicationUser> Users;
    }

    public enum HubType
    {
        DM,
        Public,
        Private
    }
}
