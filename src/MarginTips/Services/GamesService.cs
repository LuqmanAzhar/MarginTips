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
    public static class GameService
    {
        private static readonly HttpClient client = new HttpClient();
        // This needs to be dependency injected 
        // TODO: change
        static List<Game> Games { get; }

        static GameService()
        {
            Games = new List<Game>
            {
                new Game
                {
                    Id = 1,
                    Year = 2021,
                    Round = 1


                },
                new Game
                {
                    Id = 2,
                    Year = 2020,
                    Round = 2
                }
            };

        }

        private static async Task<List<Game>> ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "FootyTipping testing - ContactMe AT LuqmanAzhar.com");

            var streamTask = client.GetStreamAsync("https://api.squiggle.com.au/?q=games&year=2020");
            var responses = await JsonSerializer.DeserializeAsync<SquiggleResponse>(await streamTask);

            foreach (var game in responses.Games)
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
            return responses.Games;
        }

        public static List<Game> GetAll()
        {
            return Games;
        }

        public static Game Get(int id)
        {
            return Games.FirstOrDefault(p => p.Id == id);
        }
        public static List<Game> GetRound(int round)
        {
            return Games.FindAll(p => p.Round == round);
        }


    }
}