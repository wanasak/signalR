using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Infrastructure;
using signalR.Hubs;
using signalR.Models;

namespace signalR.Controller
{
    [Route("api/[controller]")]
    public class MessageController : ApiHubController<Broadcaster>
    {
        public MessageController(IConnectionManager connManager) : base(connManager)
        { }

        [HttpPost]
        public void Post([FromBody]ChatMessage message)
        {
            this.Clients.Group(message.MatchId.ToString()).AddChatMessage(message);
        }
    }
}