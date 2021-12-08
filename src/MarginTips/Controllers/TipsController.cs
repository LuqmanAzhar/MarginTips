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
    public class TipsController : ControllerBase
    {
        private readonly TipsService _tipsService;

        public TipsController(TipsService tipsService)
        {
            _tipsService = tipsService;
        }

        [HttpGet]
        public ActionResult<List<Tip>> GetAll()
        {
            return _tipsService.GetAll();
        }
        // TODO: Create Post Endpoint Functionality
        // [HttpPost]
        // public ActionResult Create(Player player) League?
        // {

        //     _tipsService.Create();
        // }
        // TODO: Check Other tipsServices
    }

}