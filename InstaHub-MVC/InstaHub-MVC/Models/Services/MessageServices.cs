using InstaHub_MVC.Data;
using InstaHub_MVC.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaHub_MVC.Models.Services
{
    public class MessageServices : IMessages
    {
        public InstaHubDbContext _context { get; }

        public async Task AddMessage(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Group>> GetMessages(Group group)
        {
           //Group group = await _context.Hubs.FirstOrDefaultAsync(g => g.HubID == )
           Group group = await _context.Hubs.Where(g => g.)
        }
    }
}
