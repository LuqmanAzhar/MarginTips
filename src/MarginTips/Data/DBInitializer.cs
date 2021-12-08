using MarginTips.Models;
using System;
using System.Linq;
using MarginTips.Services;

namespace MarginTips.Data
{
    public static class DBInitializer
    {
        public static void Initialize(AFLContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Teams.
            if (context.Teams.Any())
            {
                Console.WriteLine("DB Already Exsists");
                return;   // DB has been seeded
            }

            var teams = TeamsService.ProcessTeams().Result;

            foreach (Team t in teams)
            {
                Console.WriteLine($"{t.Abbrev} being added to DB");
                context.Teams.Add(t);
            }
            context.SaveChanges();

            var games = GamesService.ProcessGames().Result;
            foreach (Game g in games)
            {
                Console.WriteLine($"{g.GameID} being added to DB");
                context.Games.Add(g);
            }

            var admin = new Player
            {
                UserName = "Admin",
                Salt = "salty",
                Hash = "hash"

            };
            // TODO: Rewrite admin default Player

            Console.WriteLine($"{admin.UserName} player number: {admin.PlayerID}");
            context.Players.Add(admin);



            context.SaveChanges();
        }
    }
}