using System.Collections.Generic;
using System.Linq;
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

        // TODO: Create Method => make New league


    }
}