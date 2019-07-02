namespace InstaHub_MVC.Hubs
{
    using InstaHub_MVC.Data;
    using InstaHub_MVC.Models;
    using InstaHub_MVC.Models.Interfaces;
    using Microsoft.AspNetCore.SignalR;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="ChatHub" />
    /// </summary>
    public class ChatHub : Hub
    {
        /// <summary>
        ///  Gets or sets property for InstaHubDbContext interface
        /// </summary>
        private InstaHubDbContext _context { get; set; }

        /// <summary>
        /// Gets or sets property for IMessages interface
        /// </summary>
        private IMessages _message { get; set; }

        /// <summary>
        /// ChatHub constructor
        /// </summary>
        /// <param name="context">Handeling messages to and from database</param>
        /// <param name="message">messages comming in from the interface</param>
        public ChatHub(InstaHubDbContext context, IMessages message)
        {
            _context = context;
            _message = message;
        }

        /// <summary>
        /// TThis will send a message to all connection ID's that are currently online
        /// </summary>
        /// <param name="message">The message<see cref="string"/></param>
        /// <returns>The <see cref="Task"/>Message To All Users</returns>
        public async Task SendMessageToAll(string message)
        {
            Message m = new Message();
            m.GroupName = "Castillo Family Open Channel";
            m.UserName = Context.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;
            m.Value = message;
            m.Timestamp = DateTime.Now;

            _context.Messages.Add(m);
            await _context.SaveChangesAsync();

            await Clients.All.SendAsync("ReceiveMessage", message);
        }

        /// <summary>
        /// Send to Self 
        /// </summary>
        /// <param name="message">The message<see cref="string"/></param>
        /// <returns>The <see cref="Task"/>Message to self</returns>
        
        //Not used yet
        public Task SendMessageToCaller(string message)
        {
            return Clients.Caller.SendAsync("ReceiveMessage", message);
        }

        /// <summary>
        /// Sends message to a specific user based on their connectionId
        /// </summary>
        /// <param name="connectionId">The connectionId<see cref="string"/></param>
        /// <param name="message">The message<see cref="string"/></param>
        /// <returns>The <see cref="Task"/>Message to the individual user</returns>

        //Not used yet
        public Task SendMessageToUser(string connectionId, string message)
        {
            return Clients.Client(connectionId).SendAsync("ReceiveMessage", message);
        }

        /// <summary>
        /// This method allows you to create a group or join a group
        /// </summary>
        /// <param name="group">The group<see cref="string"/></param>
        /// <returns>The <see cref="Task"/>Added To Group/ Create A Group</returns>

        //Not used yet
        public Task JoinGroup(string group)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, group);
        }

        /// <summary>
        ///Send Message to Group will send a message to anyone in a group with you
        /// </summary>
        /// <param name="group">The group<see cref="string"/></param>
        /// <param name="message">The message<see cref="string"/></param>
        /// <returns>The <see cref="Task"/>Message To Group</returns>

        //Not used yet
        public Task SendMessageToGroup(string group, string message)
        {

            return Clients.Group(group).SendAsync("ReceiveMessage", message);
        }

        /// <summary>
        /// .On user connected we get a list of the previous messages to show the user, we get their email and connect them to chat
        /// </summary>
        /// <returns>Last N messages and User Connected</returns>
        public override async Task OnConnectedAsync()
        {
            // Refactor this with master copy
            var messages = _context.Messages.ToList();
            foreach (var message in messages)
            {
                ApplicationUser user = await _context.ApplicationUsers.FirstOrDefaultAsync(u => u.Email == message.UserName);
                await Clients.Caller.SendAsync("GetAllGeneralMessages", message, user.Avatar);

            }
            await Clients.All.SendAsync("UserConnected", Context.ConnectionId, Context.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value);
            await base.OnConnectedAsync();
        }
    }
}
