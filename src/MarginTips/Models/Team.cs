using System;
using System.Text.Json.Serialization;


namespace MarginTips.Models
{
    public class Team
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("abbrev")]
        public string Abbrev { get; set; }

        [JsonPropertyName("colour")]
        public string Colour { get; set; }
    }
}