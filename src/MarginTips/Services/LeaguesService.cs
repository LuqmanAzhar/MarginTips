using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MarginTips.Models;
using MarginTips.Data;

namespace MarginTips.Services
{
    public class LeaguesService
    {
        private readonly AFLContext _context;

        public LeaguesService(AFLContext context)
        {
            _context = context;
        }
        public List<League> GetAll()
        {
            return _context.Leagues.ToList();
        }

        public League Get(int id)
        {
            return _context.Leagues.FirstOrDefault(l => l.LeagueID == id);
        }
        //TODO: Consider is this the best way to create a new league (Maybe not a player but a token or something)
        // public void Create(Player player, League league)
        // {
        //     //TODO: Validate player and League

        //     Member member = new Member
        //     {
        //         TippingName = player.UserName,
        //         IsAdmin = true,
        //         Player = player,
        //         League = league,
        //     };

        //     _context.Leagues.Add(league);
        //     _context.Members.Add(member);
        //     _context.SaveChanges();

        //     Console.WriteLine($"League {league.LeagueName} Created");
        //     Console.WriteLine($"Admin Member: {player.UserName}");

        // }

        public List<Member> GetMembers(int id)
        {

            return _context.Members.Where(m => m.LeagueID == id).ToList();

        }

    }
}