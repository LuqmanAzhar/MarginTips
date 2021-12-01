using System;
using MarginTips.Models;
using System.Collections.Generic;
using System.Linq;



namespace MarginTips.Services
{
    public static class MatchService
    {
        static List<Match> Matches { get; }
        static int nextId = 3;

        static MatchService()
        {
            Matches = new List<Match>
            {
                new Match
                {
                    Id = 1,
                    StartTime = DateTime.Now.AddDays(-1),
                    HomeTeamID = "WCE",
                    AwayTeamID = "FRE",
                    GameComplete = true,
                    HomeScore = 100,
                    AwayScore = 86,
                },
                new Match
                {
                    Id = 2,
                    StartTime = DateTime.Now.AddDays(-1),
                    HomeTeamID = "GWS",
                    AwayTeamID = "SYD",
                    GameComplete = true,
                    HomeScore = 50,
                    AwayScore = 0,
                }
            };
        }
        public static List<Match> GetAll() => Matches;
        // returns the first or default match (=> is the return shortcut)
        public static Match Get(int id) => Matches.FirstOrDefault(m => m.Id == id);

        public static void Add(Match match)
        {
            match.Id = nextId++;
            Matches.Add(match);
        }

        public static void Delete(int id)
        {
            var match = Get(id);
            if (match is null)
                return;

            Matches.Remove(match);
        }

        public static void Update(Match match)
        {
            var index = Matches.FindIndex(m => m.Id == match.Id);
            if (index == -1)
                return;

            Matches[index] = match;
        }
    }

}
