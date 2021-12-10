using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.Json;
using MarginTips.Models;
using MarginTips.Data;

namespace MarginTips.Services
{
    public class TeamsService
    {
        private static readonly HttpClient client = new HttpClient();
        // TODO: Remove Httpclient along with the static method it realies on 

        private readonly AFLContext _context;

        public TeamsService(AFLContext context)
        {
            _context = context;
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

        public List<Team> GetAll()
        {
            return _context.Teams.ToList();
        }

        public Team Get(int id)
        {
            return _context.Teams.FirstOrDefault(p => p.TeamID == id);
        }

    }
}