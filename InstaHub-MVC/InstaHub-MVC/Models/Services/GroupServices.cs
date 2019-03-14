using InstaHub_MVC.Data;
using InstaHub_MVC.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaHub_MVC.Models.Services
{
    public class GroupServices : IGroup
    {
        private InstaHubDbContext _context { get; }

        public GroupServices(InstaHubDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Group>> GetPublicGroups()
        {
            return await _context.Groups.Where(g => g.GroupType.ToString() == Enum.GetName(typeof(GroupType), 1)).ToListAsync();
        }

    }
}
