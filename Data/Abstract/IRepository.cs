using signalR.Models;

namespace signalR.Data.Abstract
{
    public interface IMatchRepository : IEntityBaseRepository<Match> { }

    public interface IFeedRepository : IEntityBaseRepository<Feed> { }
}