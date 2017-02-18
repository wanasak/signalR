using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Infrastructure;
using signalR.Data.Abstract;
using signalR.Hubs;
using signalR.Models;

namespace signalR.Controller
{
    [Route("api/[controller]")]
    public class MatchesController : ApiHubController<Broadcaster>
    {
        IMatchRepository _matchRepository;

        public MatchesController(
            IConnectionManager connManager,
            IMatchRepository matchRepository)
        : base(connManager)
        {
            _matchRepository = matchRepository;
        }

        [HttpGet]
        public IEnumerable<MatchViewModel> Get()
        {
            IEnumerable<Match> _matches = _matchRepository.AllIncluding(m => m.Feeds);
            IEnumerable<MatchViewModel> _matchesVM = Mapper.Map<IEnumerable<Match>, IEnumerable<MatchViewModel>>(_matches);
            return _matchesVM;
        }

        [HttpPut]
        public async void Put(int id, [FromBody]MatchScore score)
        {
            Match _match = _matchRepository.GetSingle(id);
            _match.HostScore = score.HostScore;
            _match.GuestScore = score.GuestScore;
            
            _matchRepository.Commit();

            MatchViewModel _matchVM = Mapper.Map<Match, MatchViewModel>(_match);
            await Clients.All.UpdateMatch(_matchVM);
        }
    }
}