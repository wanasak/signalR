using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Infrastructure;
using signalR.Data.Abstract;
using signalR.Hubs;
using signalR.Models;

namespace signalR.Controller
{
    [Route("api/[controller]")]
    public class FeedController : ApiHubController<Broadcaster>
    {
        IMatchRepository _matchRepository;
        IFeedRepository _feedRepository;

        public FeedController(
            IConnectionManager connManager,
            IMatchRepository matchRepository,
            IFeedRepository feedRepository) 
            : base(connManager)
        {
            _matchRepository = matchRepository;
            _feedRepository = feedRepository;
        }

        [HttpPost]
        public async void Post([FromBody]FeedViewModel feed)
        {
            Match _match = _matchRepository.GetSingle(feed.MatchId);
            Feed _feed = new Feed()
            {
                Description = feed.Description,
                CreatedAt = feed.CreatedAt,
                MatchId = feed.MatchId
            };
            _match.Feeds.Add(_feed);
            _matchRepository.Commit();

            FeedViewModel _feedVm = Mapper.Map<Feed, FeedViewModel>(_feed);
            
            await Clients.Group(feed.MatchId.ToString()).AddFeed(_feedVm);
        }
    }
}