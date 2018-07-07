using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contest.Models
{
    public class WinnerDto : ContestantDto
    {
        private readonly ContestantDto winningContestant;
        private readonly PrizeDto prize;

        public WinnerDto(ContestantDto winningContestant, PrizeDto prize)
        {
            this.winningContestant = winningContestant;
            this.prize = prize;
        }

        public string PrizeName { get; set; }

        internal new static PrizeDto FromCsvLine(string line)
        {
            throw new NotImplementedException();
        }
    }
}
