
namespace MarginTips.Models
{
    public class League
    {
        public int LeagueID { get; set; }
        public string Name { get; set; }
        // TODO: Adjust Scoring System
        public int ScoringSystem { get; set; }

        // TODO: Add relationship to League Player Table 
        // TODO: Add relationship to Tips Table
    }
}