using signalR.Data.Abstract;
using signalR.Models;

namespace signalR.Data.Repository
{
    public class FeedRepository : EntityBaseRepository<Feed>, IFeedRepository
    {
        public FeedRepository(LiveGameContext context) : base(context) { }
    }
}