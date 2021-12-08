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
        public TeamsController()
        // fix naming convention on URI capitalization
        {
        }

        [HttpGet]
        public ActionResult<List<Team>> GetAll()
        {
            return TeamsService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Team> Get(int id)
        {
            var team = TeamsService.Get(id);

            if (team == null)
                return NotFound();

            return team;
        }
    }
}