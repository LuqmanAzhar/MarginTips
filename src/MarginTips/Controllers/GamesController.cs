using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MarginTips.Models;
using MarginTips.Services;

namespace MarginTips.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly GamesService _gamesService;
        public GamesController(GamesService gamesService)
        // interface
        {
            _gamesService = gamesService;
        }

        [HttpGet]
        public ActionResult<List<Game>> GetAll()
        {
            return _gamesService.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<Game> Get(int id)
        {
            var game = _gamesService.Get(id);

            if (game == null)
                return NotFound();

            return game;
        }
        [HttpGet("round/{round}")]
        public ActionResult<List<Game>> GetRound(int round)
        {
            return _gamesService.GetRound(round);
        }

    }

}