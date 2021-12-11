using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;


namespace MarginTips.Models
{
    public class Team
    {
        [JsonPropertyName("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TeamID { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("abbrev")]
        public string Abbrev { get; set; }

        [JsonPropertyName("colour")]
        public string PrimaryColour { get; set; }
        public string SecondaryColour { get; set; }
        public string TextColour { get; set; }
    }
}