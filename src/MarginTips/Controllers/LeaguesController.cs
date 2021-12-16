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
        // TODO: Verify if player is authorized and Authenticated
        // TODO: Get player info without adding a player model into the answer
        // [HttpPost]
        // public ActionResult Create(League league)
        // {
        //     _leagueService.Create(player, league);
        //     return Ok();
        // }
        [HttpGet("{id}")]
        public ActionResult<League> GetLeague(int id)
        {
            var league = _leagueService.Get(id);

            if (league == null)
                return NotFound();

            return Ok(league);
        }

        [HttpGet("{id}/members")]
        public ActionResult<Member> GetMembers(int id)
        {
            var members = _leagueService.GetMembers(id);

            if (members == null)
                return NotFound();

            return Ok(members);
        }


    }

}