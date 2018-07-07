using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contest.Models;
using Contest.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Contest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly IContestantRepository _contestantRepository;

        public ParticipantsController(IContestantRepository contestantRepository)
        {
            _contestantRepository = contestantRepository ?? throw new ArgumentNullException("IContestantRepository");
        }

        // GET api/participants
        [HttpGet]
        public ActionResult<IEnumerable<ContestantDto>> Get()
        {
            var result = _contestantRepository.GetAll();

            return Ok(result);
        }
    }
}
