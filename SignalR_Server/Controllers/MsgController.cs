using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR_Server.Business;
using SignalR_Server.Hubs;

namespace SignalR_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MsgController : ControllerBase
    {
        private readonly MessageBusiness _messageBusiness;
        private readonly IHubContext<MessageHub> _hubContext;
        public MsgController(MessageBusiness messageBusiness, IHubContext<MessageHub> hubContext)
        {
            _messageBusiness = messageBusiness;
            _hubContext = hubContext;
        }
        [HttpGet("message")]
        public async Task<IActionResult> Index(string message)
        {
            await _messageBusiness.SendMessage(message);
            return Ok();
        }
    }
}
