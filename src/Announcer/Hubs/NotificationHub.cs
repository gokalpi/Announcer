using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Announcer.Hubs
{
    public class NotificationHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("UserConnected", Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception ex)
        {
            await Clients.All.SendAsync("UserDisconnected", Context.ConnectionId);
            await base.OnDisconnectedAsync(ex);
        }

        public async Task AddToGroupAsync(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName).SendAsync("JoinedGroup", Context.ConnectionId, groupName);
        }

        public async Task RemoveFromGroupAsync(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName).SendAsync("LeftGroup", Context.ConnectionId, groupName);
        }

        public Task SendMessageToAll(string message)
        {
            return Clients.All.SendAsync("ReceiveMessage", message);
        }

        public Task SendMessageToCaller(string message)
        {
            return Clients.Caller.SendAsync("ReceiveMessage", message);
        }

        public Task SendMessageToGroup(string group, string message)
        {
            return Clients.Group(group).SendAsync("ReceiveGroupMessage", new
            {
                Group = group,
                Message = message
            });
        }

        public Task SendMessageToUser(string user, string message)
        {
            return Clients.Client(user).SendAsync("ReceiveMessage", message);
        }
    }
}