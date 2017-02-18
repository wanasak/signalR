using signalR.Data.Abstract;
using signalR.Models;

namespace signalR.Data.Repository
{
    public class MatchRepository : EntityBaseRepository<Match>, IMatchRepository
    {
        public MatchRepository(LiveGameContext context) : base(context) { }
    }
}