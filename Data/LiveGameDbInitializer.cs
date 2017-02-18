using System;
using System.Collections.Generic;
using System.Linq;
using signalR.Models;

namespace signalR.Data.Abstract
{
    public class LiveGameDbInitializer
    {
        private static LiveGameContext context;
        public static void Initilize(IServiceProvider serviceProvider)
        {
            context = (LiveGameContext)serviceProvider.GetService(typeof(LiveGameContext));
            InitilizeDatabase();
        }
        private static void InitilizeDatabase()
        {
            if (!context.Matches.Any())
            {
                Match match_01 = new Match
                {
                    Host = "Team 1",
                    Guest = "Team 2",
                    HostScore = 0,
                    GuestScore = 0,
                    MatchDate = DateTime.Now,
                    Type = MatchTypeEnum.Basketball,
                    Feeds = new List<Feed>
                    {
                        new Feed()
                        {
                            Description = "Match started",
                            MatchId = 1,
                            CreatedAt = DateTime.Now
                        }
                    }
                };

                Match match_02 = new Match
                {
                    Host = "Team 3",
                    Guest = "Team 4",
                    HostScore = 0,
                    GuestScore = 0,
                    MatchDate = DateTime.Now,
                    Type = MatchTypeEnum.Basketball,
                    Feeds = new List<Feed>
                    {
                        new Feed()
                        {
                            Description = "Match started",
                            MatchId = 2,
                            CreatedAt = DateTime.Now
                        }
                    }
                };

                context.Matches.Add(match_01); context.Matches.Add(match_02);

                context.SaveChanges();
            }
        }
    }
}