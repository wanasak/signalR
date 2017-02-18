using System;
using System.Collections.Generic;

namespace signalR.Models
{
    public class Match : IEntityBase
    {
        public Match()
        {
            Feeds = new List<Feed>();
        }

        public int Id { get; set; }
        public string Host { get; set; }
        public string Guest { get; set; }
        public int HostScore { get; set; }
        public int GuestScore { get; set; }
        public DateTime MatchDate { get; set; }
        public MatchTypeEnum Type { get; set; }
        public ICollection<Feed> Feeds { get; set; }
    }
}