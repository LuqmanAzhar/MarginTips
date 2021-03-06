using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using MarginTips.Models;
using MarginTips.Data;

namespace MarginTips.Services
{
    public class GamesService
    {
        // TODO: Why do i want to pass this object to the controller instead of just use the methods
        private static readonly HttpClient client = new HttpClient();

        private readonly AFLContext _context;
        // This needs to be dependency injected 
        // TODO: Remove HttpClient
        public GamesService(AFLContext context)
        //interface 
        {
            _context = context;
        }

        public static async Task<List<Game>> ProcessGames()
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

        // TODO: When Called check if the game is complete

        public List<Game> GetAll()
        {
            // TODO: Figure out how to paginiate large Requests ?
            return _context.Games.Include(g => g.HTeam).Include(g => g.ATeam).ToList();
        }

        public Game Get(int id)
        {
            return _context.Games.FirstOrDefault(p => p.GameID == id);
        }
        public List<Game> GetRound(int round)
        {
            return _context.Games.Include(t => t.HTeam).Include(t => t.ATeam).Where(g => g.Round == round).ToList();
        }


        // TODD: Stored Context of Games for the day => On wake up check Context of Games => Request 
        //  => Next Day for New Context

        // TODO: Best Case After Game 


    }
}