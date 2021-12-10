
namespace MarginTips.Models
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string UserName { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }

        // TODO: relationship to League Player Table
        // TODO: relationship to Tips Table
    }
}
