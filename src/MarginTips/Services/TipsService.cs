using System;
using System.Collections.Generic;
using System.Linq;
using MarginTips.Models;
using MarginTips.Data;

namespace MarginTips.Services
{
    public class TipsService
    {
        private readonly AFLContext _context;

        public TipsService(AFLContext context)
        {
            _context = context;
        }
        public List<Tip> GetAll()
        {
            return _context.Tips.ToList();
        }

        // TODO: Create Tips Remeber to add datetime on 

        // TODO: Game Tips

        // TODO: League Tips

        // TODO: Player Tips

        // TODO: Round Tips
    }
}