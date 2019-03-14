using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaHub_MVC.Models.Interfaces
{
    interface IMessages
    {
        Task AddMessage(Message message);

        Task<List<Group>> GetMessages(Group group);
    }
}
