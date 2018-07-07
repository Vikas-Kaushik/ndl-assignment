using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contest.Models;
using Contest.Repositories;

namespace Contest.Services
{
    public interface IJudge
    {
        void AddPrizes(IEnumerable<PrizeDto> prizes);
        void Consider(ContestantDto contestant);
        void SaveWinners(IWinnerRepository winnerRepository);
    }
}
