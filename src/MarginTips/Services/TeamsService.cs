using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.Json;
using MarginTips.Models;

namespace MarginTips.Services
{
    public static class TeamsService
    {
        private static readonly HttpClient client = new HttpClient();
        // This needs to be dependency injected 
        // TODO: Remove Httpclient
        static List<Team> Teams { get; }

        static TeamsService()
        {
            Teams = new List<Team>
            {
                new Team
                {
                    TeamID = 1,
                    Abbrev = "WCE",
                    Name = "West Coast",
                    Colour = "#003087"

                },
                new Team
                {
                    TeamID = 2,
                    Abbrev = "SYD",
                    Name = "Sydney",
                    Colour = "#ed171f"
                }
            };

        }

        public static async Task<List<Team>> ProcessTeams()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "FootyTipping testing - ContactMe AT LuqmanAzhar.com");

            var streamTask = client.GetStreamAsync("https://api.squiggle.com.au/?q=teams");
            var responses = await JsonSerializer.DeserializeAsync<SquiggleResponse>(await streamTask);

            foreach (var game in responses.Teams)
            {
                // Console.WriteLine(JsonSerializer.Serialize(game));
                // Console.WriteLine(game.Id);
                // Console.WriteLine(game.Year);
                // Console.WriteLine(game.Round);
                // Console.WriteLine(game.RoundName);
                // Console.WriteLine(game.LocalTime);
                // Console.WriteLine(game.Tz);
                // Console.WriteLine(game.ABehinds);
                // Console.WriteLine(game.AGoals);
                // Console.WriteLine();
            }
            return responses.Teams;
        }

        public static List<Team> GetAll()
        {
            return ProcessTeams().Result;
        }

        public static Team Get(int id)
        {
            return Teams.FirstOrDefault(p => p.TeamID == id);
        }

    }
}