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

        public ICollection<Member> Members { get; set; }
        public ICollection<Tip> Tips { get; set; }

    }
}