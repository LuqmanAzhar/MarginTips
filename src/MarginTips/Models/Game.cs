using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;



namespace MarginTips.Models
{
    public class Game
    {
        [JsonPropertyName("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GameID { get; set; }
        [JsonPropertyName("year")]
        public int Year { get; set; }
        [JsonPropertyName("round")]
        public int Round { get; set; }
        [JsonPropertyName("roundname")]
        public string RoundName { get; set; }
        [JsonPropertyName("hteamid")]
        public int HTeamID { get; set; }
        [JsonPropertyName("ateamid")]
        public int ATeamID { get; set; }
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
        public Team HTeam { get; set; }
        public Team ATeam { get; set; }
    }
}