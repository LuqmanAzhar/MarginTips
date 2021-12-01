using System;

namespace MarginTips.Models
{
    public class Match
    {
        public long Id { get; set; }
        public DateTime StartTime { get; set; }

        //TODO: Change to Team Type possibly in the future
        public string HomeTeamID { get; set; }

        public string AwayTeamID { get; set; }

        public bool GameComplete { get; set; }

        public int HomeScore { get; set; }

        public int AwayScore { get; set; }

    }
}
