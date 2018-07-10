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
        public const string filePath = "Data\\winners.csv";

        public IEnumerable<WinnerDto> GetAll()
        {
            if (!File.Exists(filePath)) this.Reset();

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

        public void Reset()
        {
            string firstLine = "id,name,email,date_participated,prize" + Environment.NewLine;
            File.WriteAllText(filePath, firstLine);
        }

        public void Write(WinnerDto winnerDto)
        {
            File.AppendAllText(filePath, WinnerDto.ToCsvLine(winnerDto));
        }
    }
}
