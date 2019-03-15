using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstaHub_MVC.Models.Interfaces;
using InstaHub_MVC.Models;
using InstaHub_MVC.Data;
using Microsoft.EntityFrameworkCore;

namespace InstaHub_MVC.Hubs
{
    public class ChatHub : Hub
    {
        private InstaHubDbContext _context { get; set; }
        private IMessages _message { get; set; }

        public ChatHub(InstaHubDbContext context, IMessages message)
        {
            _context = context;
            _message = message;
        }

        public async Task SendMessageToAll(string message)
        {
            Message m = new Message();
            m.GroupName = "general";
            m.UserName = Context.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;
            m.Value = message;
            m.Timestamp = DateTime.Now;

            _context.Messages.Add(m);
            await _context.SaveChangesAsync();

            await Clients.All.SendAsync("ReceiveMessage",  message);
        }

        public Task SendMessageToCaller(string message)
        {
            return Clients.Caller.SendAsync("ReceiveMessage", message);
        }

        public Task SendMessageToUser(string connectionId, string message)
        {
            return Clients.Client(connectionId).SendAsync("ReceiveMessage", message);
        }

        public Task JoinGroup(string group)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, group);
        }

        public Task SendMessageToGroup(string group, string message)
        {

            return Clients.Group(group).SendAsync("ReceiveMessage", message);
        }

        //TODO GET ALL MESSAGES FROM GENERAL
        public override async Task OnConnectedAsync()
        {
            // Refactor this with master copy
            var messages =  _context.Messages.ToList();
            foreach(var message in messages)
            {
                ApplicationUser user = await _context.ApplicationUsers.FirstOrDefaultAsync(u => u.Email == message.UserName);
                await Clients.Caller.SendAsync("GetAllGeneralMessages", message, user.Avatar);

            }
            await Clients.All.SendAsync("UserConnected", Context.ConnectionId, Context.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value);
            await base.OnConnectedAsync();
        }
    }
}
