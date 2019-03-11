using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaHub_MVC.Models
{
    public class Message
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public int HubID { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }

        public Hub Hub;
        public ApplicationUser User;
    }
}
