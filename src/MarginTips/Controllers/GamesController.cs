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
        public GamesController()
        // fix naming convention on URI capitalization
        {
        }

        [HttpGet]
        public ActionResult<List<Game>> GetAll()
        {
            return GamesService.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<Game> Get(int id)
        {
            var match = GamesService.Get(id);

            if (match == null)
                return NotFound();

            return match;
        }
        [HttpGet("round/{round}")]
        public ActionResult<List<Game>> GetRound(int round)
        {
            return GamesService.GetRound(round);
        }


    }

}