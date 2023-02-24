using Microsoft.AspNetCore.SignalR;
using SignalR_Server.Hubs;

namespace SignalR_Server.Business
{
    public class MessageBusiness
    {
        readonly IHubContext<MessageHub> _hubContext;
        public MessageBusiness(IHubContext<MessageHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public async Task SendMessage(string message)
        {
            await  _hubContext.Clients.All.SendAsync("recieveMessage", message);
        }

    }
}
