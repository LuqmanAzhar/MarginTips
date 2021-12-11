using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarginTips.Models
{
    public class League
    {
        public int LeagueID { get; set; }
        [Required]
        public string LeagueName { get; set; }
        // TODO: Adjust Scoring System
        [Required]
        public int ScoringSystem { get; set; }
        // TODO: Scoring Types
        // Correct Tips (WHo Wins) QUANTITY OVER SEASON 
        // Best Round Correct Tips in a round Best performer
        // Best Round Margin
        // Best TOTAL MARGIN <= Average margin
        // Rounds Won 
        // Rounds Lost
        // Exact Margins
        // 1 Point Margins
        // 6 point margins
        // X MARGIN 
        // Margin Inequalities i.e Less then 7 points

        public ICollection<Member> Members { get; set; }
        public ICollection<Tip> Tips { get; set; }

    }
}