using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using signalR.Models;

namespace signalR.Hubs
{
    public class Broadcaster : Hub<IBroadcaster>
    {
        public override Task OnConnected()
        {
            // set connection id for just connected only
            return Clients.Client(Context.ConnectionId)
                .SetConnectionId(Context.ConnectionId);
        }
        // server side mothods called from client
        public Task Subscribe(int matchId)
        {
            return Groups.Add(Context.ConnectionId, matchId.ToString());
        }
        public Task Unsubscribe(int matchId)
        {
            return Groups.Remove(Context.ConnectionId, matchId.ToString());
        }
    }
    // client side methods to be invorked by broadcaster hub
    public interface IBroadcaster
    {
        Task SetConnectionId(string connectionId);
        Task UpdateMatch(MatchViewModel match);
        Task AddFeed(FeedViewModel feed);
        Task AddChatMessage(ChatMessage msg);
    }
}