using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Contest.Models;

namespace Contest.Repositories
{
    public class WinnerRepository : IWinnerRepository
    {
        public IEnumerable<WinnerDto> GetAll()
        {
            string filePath = "Data\\entries.csv";

            using (var fileStream = File.OpenText(filePath))
            {
                // first line
                var line = fileStream.ReadLine();

                while (!fileStream.EndOfStream)
                {
                    line = fileStream.ReadLine();

                    yield return WinnerDto.FromCsvLine(line);
                }
            }
        }

        public void Write(WinnerDto winnerDto)
        {
            throw new NotImplementedException();
        }
    }
}
