using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;



namespace MarginTips.Models
{
    public class SquiggleResponse
    {
        [JsonPropertyName("games")]
        public List<Game> Games { get; set; }
    }

}