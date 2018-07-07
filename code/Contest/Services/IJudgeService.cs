using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contest.Models;

namespace Contest.Services
{
    public interface IJudgeService
    {
        IEnumerable<WinnerDto> GetWinners();
        void DeclareWinners();
    }
}
