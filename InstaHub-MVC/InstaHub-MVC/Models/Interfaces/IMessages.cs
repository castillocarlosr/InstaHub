using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaHub_MVC.Models.Interfaces
{
    public interface IMessages
    {
        Task AddMessage(Message message);

        Task<IEnumerable<Message>> GetMessages(int groupName);
    }
}
