using Microsoft.AspNetCore.SignalR;
using SignalR_Server.Interfaces;

namespace SignalR_Server.Hubs
{
    public class MessageHub : Hub<IMessageClient> 
    {
        public List<string> clients=new List<string>();
        public override async Task OnConnectedAsync()
        {
            clients.Add(Context.ConnectionId);
            await Clients.All.Clients(clients);
            await Clients.All.UserJoined(Context.ConnectionId);
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clients.Remove(Context.ConnectionId);
            await Clients.All.Clients(clients);
            await Clients.All.UserLeaved(Context.ConnectionId);
        }
    }
}
