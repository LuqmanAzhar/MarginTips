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

            var teamColours = new List<AFLTeamColours>
            {
                new AFLTeamColours
                {
                    Abbrev = "ADE",
                    PrimaryColour =  "#002b5c",
                    SecondaryColour =  "#e21937",
                    TextColour =  "#ffd200"
                },
                new AFLTeamColours
                {
                    Abbrev = "BRI",
                    PrimaryColour = "#7c0040",
                    SecondaryColour = "#fdbe57",
                    TextColour = "#ffffff"
                },
                new AFLTeamColours
                {
                    Abbrev = "CAR",
                    PrimaryColour = "#031a29",
                    SecondaryColour = "#031a29",
                    TextColour = "#ffffff"
                },
                new AFLTeamColours
                {
                    Abbrev = "COL",
                    PrimaryColour = "#ffffff",
                    SecondaryColour = "#000000",
                    TextColour = "#000000"
                },
                new AFLTeamColours
                {
                    Abbrev = "ESS",
                    PrimaryColour = "#000000",
                    SecondaryColour = "#cc2031",
                    TextColour = "#ffffff"
                },
                new AFLTeamColours
                {
                    Abbrev = "FRE",
                    PrimaryColour = "#2a0d54",
                    SecondaryColour = "#2a0d54",
                    TextColour = "#ffd200"
                },
                new AFLTeamColours
                {
                    Abbrev = "GEE",
                    PrimaryColour = "#ffffff",
                    SecondaryColour = "#002b5c",
                    TextColour = "#000000"
                },
                new AFLTeamColours
                {
                    Abbrev = "GC",
                    PrimaryColour = "#ee3728",
                    SecondaryColour = "#ffdf16",
                    TextColour = "#ffffff"
                },
                new AFLTeamColours
                {
                    Abbrev = "GWS",
                    PrimaryColour = "#f47920",
                    SecondaryColour = "#f47920",
                    TextColour = "#ffffff"
                },
                new AFLTeamColours
                {
                    Abbrev = "HAW",
                    PrimaryColour = "#4d2004",
                    SecondaryColour = "#fbbf15",
                    TextColour = "#ffffff"
                },
                new AFLTeamColours
                {
                    Abbrev = "MEL",
                    PrimaryColour = "#0f1131",
                    SecondaryColour = "#cc2031",
                    TextColour = "#ffffff"
                },
                new AFLTeamColours
                {
                    Abbrev = "NOR",
                    PrimaryColour = "#ffffff",
                    SecondaryColour = "#1a3b8e",
                    TextColour = "#000000"
                },
                new AFLTeamColours
                {
                    Abbrev = "POR",
                    PrimaryColour = "#008aab",
                    SecondaryColour = "#000000",
                    TextColour = "#ffffff"
                },
                new AFLTeamColours
                {
                    Abbrev = "RIC",
                    PrimaryColour = "#ffd200",
                    SecondaryColour = "#000000",
                    TextColour = "#000000"
                },
                new AFLTeamColours
                {
                    Abbrev = "STK",
                    PrimaryColour = "#ed1b2f",
                    SecondaryColour = "#000000",
                    TextColour = "#ffffff"
                },
                new AFLTeamColours
                {
                    Abbrev = "SYD",
                    PrimaryColour = "#ffffff",
                    SecondaryColour = "#ed171f",
                    TextColour = "#000000"
                    },
                new AFLTeamColours
                {
                    Abbrev = "WCE",
                    PrimaryColour = "#003087",
                    SecondaryColour = "#f2a900",
                    TextColour = "#ffffff"
                },
                new AFLTeamColours
                {
                    Abbrev = "WBD",
                    PrimaryColour = "#1a529e",
                    SecondaryColour = "#be0027",
                    TextColour = "#ffffff"
                }
            };

            foreach (Team t in teams)
            {
                var g = teamColours.Find(g => g.Abbrev == t.Abbrev);
                t.PrimaryColour = g.PrimaryColour;
                t.SecondaryColour = g.SecondaryColour;
                t.TextColour = g.TextColour;

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
                new Tip {GameID=5599,Margin=10,IsHomeTipped=true,
                Player=admin, League=league},
                new Tip {GameID=5600,Margin=0,IsHomeTipped=false,
                Player=admin, League=league},
                new Tip {GameID=6239,Margin=5,IsHomeTipped=false,
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
