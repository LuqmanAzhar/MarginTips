using System;
using System.Text.Json.Serialization;


namespace MarginTips.Models
{
    public class Game
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("year")]
        public int Year { get; set; }
        [JsonPropertyName("round")]
        public int Round { get; set; }
        [JsonPropertyName("roundname")]
        public string RoundName { get; set; }
        [JsonPropertyName("hteamid")]
        public int HTeamId { get; set; }
        [JsonPropertyName("ateamid")]
        public int ATeamId { get; set; }
        [JsonPropertyName("agoals")]
        public int AGoals { get; set; }
        [JsonPropertyName("hgoals")]
        public int HGoals { get; set; }
        [JsonPropertyName("abehinds")]
        public int ABehinds { get; set; }
        [JsonPropertyName("hbehinds")]
        public int HBehinds { get; set; }
        [JsonPropertyName("localtime")]
        public string LocalTime { get; set; }
        [JsonPropertyName("tz")]
        public string Tz { get; set; }
    }
}