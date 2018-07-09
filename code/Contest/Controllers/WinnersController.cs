using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contest.Models;
using Contest.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WinnersController : ControllerBase
    {
        private readonly IJudgeService _judgeService;
        public WinnersController(IJudgeService judgeService)
        {
            _judgeService = judgeService ?? throw new ArgumentNullException("judgeService");
        }

        // GET api/winners
        [HttpGet]
        public ActionResult<IEnumerable<WinnerDto>> Get()
        {
            return Ok(_judgeService.GetWinners());
        }

        // POST api/winners
        [HttpPost]
        public ActionResult<IEnumerable<WinnerDto>> Post()
        {
            _judgeService.DeclareWinners();

            return Ok(_judgeService.GetWinners());
        }
    }
}
