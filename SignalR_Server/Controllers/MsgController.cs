using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR_Server.Business;

namespace SignalR_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MsgController : ControllerBase
    {
        private readonly MessageBusiness _messageBusiness;
        public MsgController(MessageBusiness messageBusiness)
        {
            _messageBusiness = messageBusiness;
        }
        [HttpGet("message")]
        public async Task<IActionResult> Index(string message)
        {
            await _messageBusiness.SendMessage(message);
            return Ok();
        }
    }
}
