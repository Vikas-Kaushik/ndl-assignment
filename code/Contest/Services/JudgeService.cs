using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contest.Models;
using Contest.Repositories;

namespace Contest.Services
{
    public class JudgeService : IJudgeService
    {
        private readonly IWinnerRepository _winnerRepository;
        private readonly IPrizeRepository _prizeRepository;
        private readonly IContestantRepository _contestantRepository;
        private readonly IJudge _judge;

        public JudgeService(
            IJudge judge, 
            IWinnerRepository winnerRepository, 
            IPrizeRepository prizeRepository,
            IContestantRepository contestantRepository)
        {
            _winnerRepository = winnerRepository ?? throw new ArgumentNullException("winnerRepository");
            _prizeRepository = prizeRepository ?? throw new ArgumentNullException("prizeRepository");
            _contestantRepository = contestantRepository ?? throw new ArgumentNullException("contestantRepository");
            _judge = judge ?? throw new ArgumentNullException("Judge");
        }

        public void DeclareWinners()
        {
            // Inform the judge about prizes
            _judge.AddPrizes(_prizeRepository.GetAll());

            // Ask the judge to consider each contestant for prizes
            foreach (var contestant in _contestantRepository.GetAll())
            {                
                _judge.Consider(contestant);            
            }

            // Ask the judge to save the judgement
            _judge.SaveWinners(_winnerRepository);
        }

        public IEnumerable<WinnerDto> GetWinners()
        {
            return _winnerRepository.GetAll();
        }
    }
}
