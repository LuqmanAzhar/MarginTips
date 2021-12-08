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
    public class PlayersController : ControllerBase
    {
        private readonly PlayersService _playerService;

        public PlayersController(PlayersService playersService)
        {
            _playerService = playersService;
        }

        [HttpGet]
        public ActionResult<List<Player>> GetAll()
        {
            return _playerService.GetAll();
        }
        // TODO: Create Post Endpoint Functionality
        // [HttpPost]
        // public ActionResult Create(player player)
        // {

        //     LeaguesService.Create();
        // }
        [HttpGet("{id}")]
        public ActionResult<Player> Get(int id)
        {
            var player = _playerService.Get(id);

            if (player == null)
                return NotFound();

            return player;
        }
        // TODO: Expose which leagues the player is part of 

    }

}