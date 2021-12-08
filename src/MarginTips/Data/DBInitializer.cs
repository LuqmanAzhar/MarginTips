using System;
using System.Linq;
using System.Collections.Generic;
using MarginTips.Services;
using MarginTips.Models;

namespace MarginTips.Data
{
    public static class DBInitializer
    {
        public static void Initialize(AFLContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Teams.
            if (context.Tips.Any())
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

            var league = new League
            {
                LeagueName = "TestLeague",
                ScoringSystem = 1
            };

            Console.WriteLine($"{league.LeagueName} being added");
            context.Leagues.Add(league);

            var member = new Member
            {
                League = league,
                Player = admin,
                TippingName = "Best Tipper",
                IsAdmin = true
            };

            Console.WriteLine($"{admin.UserName} added to {league.LeagueName}");
            context.Members.Add(member);

            var tips = new List<Tip>
            {
                new Tip {GameID=5599,Margin=10,HomeWin=true,
                Player=admin, League=league},
                new Tip {GameID=5600,Margin=0,HomeWin=false,
                Player=admin, League=league},
                new Tip {GameID=6239,Margin=5,HomeWin=false,
                Player=admin, League=league}
            };

            foreach (Tip t in tips)
            {
                context.Tips.Add(t);
                Console.WriteLine($"{t.Margin} is added");
            }


            context.SaveChanges();
        }
    }
}
