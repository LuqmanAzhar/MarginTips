
namespace MarginTips.Models
{
    public class Tip
    {
        public int PlayerID { get; set; }
        public int LeagueID { get; set; }
        public int GameID { get; set; }
        public int Margin { get; set; }
        public bool HomeWin { get; set; }

        public Game Game { get; set; }
        public Player Player { get; set; }
        public League League { get; set; }

        // Todo: add complex attributes determining Tip correctness?
    }
}