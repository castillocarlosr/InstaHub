using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaHub_MVC.Models
{
    public class Message
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int GroupID { get; set; }
        public string Value { get; set; }
        public DateTime Timestamp { get; set; }

        public Group Group;
        public ApplicationUser User;
    }
}
