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
    public class TeamsController : ControllerBase
    {
        private readonly TeamsService _teamsService;
        public TeamsController(TeamsService teamsService)
        {
            _teamsService = teamsService;
        }

        [HttpGet]
        public ActionResult<List<Team>> GetAll()
        {
            return _teamsService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Team> Get(int id)
        {
            var team = _teamsService.Get(id);

            if (team == null)
                return NotFound();

            return team;
        }
    }
}