using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FRIWOCenter.Shared.Models;
using Microsoft.AspNetCore.SignalR;

namespace FRIWOCenter.WebHost.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message)
        {
            var users = new string[] { message.ToUserId, message.FromUserId };
            //await Clients.Users(users).SendAsync("ReceiveMessage", message);
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}