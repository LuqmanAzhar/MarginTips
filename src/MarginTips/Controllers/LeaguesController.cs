using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MarginTips.Models;
using MarginTips.Services;
using MarginTips.Data;

namespace MarginTips.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeaguesController : ControllerBase
    {
        private readonly LeaguesService _leagueService;

        public LeaguesController(LeaguesService leaguesService)
        {
            _leagueService = leaguesService;
        }

        [HttpGet]
        public ActionResult<List<League>> GetAll()
        {
            return _leagueService.GetAll();
        }
        // TODO: Create Post Endpoint Functionality
        // [HttpPost]
        // public ActionResult Create(Player player, League league)
        // {
        //     _leagueService.Create(player, league);
        //     return NotFound();
        // }
        [HttpGet("{id}")]
        public ActionResult<League> Get(int id)
        {
            var league = _leagueService.Get(id);

            if (league == null)
                return NotFound();

            return Ok();
        }
        // TODO: Members Resource Expose

    }

}