using System.ComponentModel.DataAnnotations;

namespace MarginTips.Models
{
    public class Member
    {
        public int PlayerID { get; set; }
        public int LeagueID { get; set; }
        [Required]
        public string TippingName { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
        // TODO: Flesh out abilities make New table and link to this

        public Player Player { get; set; }
        public League League { get; set; }
        // TODO: Add relationship to League Player Table 
        // TODO: Add relationship to Tips Table
    }
}