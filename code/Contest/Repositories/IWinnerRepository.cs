using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contest.Models;

namespace Contest.Repositories
{
    public interface IWinnerRepository
    {
        IEnumerable<WinnerDto> GetAll();
        void Write(WinnerDto winner);
        void Reset();
    }
}
