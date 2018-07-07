using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Contest.Models;

namespace Contest.Repositories
{
    public class PrizeRepository : IPrizeRepository
    {
        public IEnumerable<PrizeDto> GetAll()
        {
            string filePath = "Data\\entries.csv";

            using (var fileStream = File.OpenText(filePath))
            {
                // first line
                var line = fileStream.ReadLine();

                while (!fileStream.EndOfStream)
                {
                    line = fileStream.ReadLine();

                    yield return PrizeDto.FromCsvLine(line);
                }
            }
        }
    }
}
