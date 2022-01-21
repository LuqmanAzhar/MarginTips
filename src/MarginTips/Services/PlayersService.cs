using System;
using System.Collections.Generic;
using System.Linq;
using MarginTips.Models;
using MarginTips.Data;

namespace MarginTips.Services
{
    public class PlayersService
    {
        private readonly AFLContext _context;

        public PlayersService(AFLContext context)
        {
            _context = context;
        }
        public List<Player> GetAll()
        {
            return _context.Players.ToList();
        }

        public Player Get(int id)
        {
            return _context.Players.FirstOrDefault(p => p.PlayerID == id);
        }

        public void Create(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();

            //TODO: Remove Player added notification on the Console
            Console.WriteLine($"Added Player ID:{player.PlayerID}");
        }

        // TODO: Create Method => Get Leagues of player

        // TODO: Create Method => Get Tips of Leagues of player


    }
}