using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MarginTips.Models;
using MarginTips.Services;

namespace MarginTips.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        public GameController()
        // fix naming convention on URI capitalization
        {
        }

        [HttpGet]
        public ActionResult<List<Game>> GetAll()
        {
            return GameService.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<Game> Get(int id)
        {
            var match = GameService.Get(id);

            if (match == null)
                return NotFound();

            return match;
        }
        [HttpGet("round/{round}")]
        public ActionResult<List<Game>> GetRound(int round)
        {
            return GameService.GetRound(round);
        }


    }

}