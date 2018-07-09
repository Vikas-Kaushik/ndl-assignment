using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contest.Models
{
    public class WinnerDto : ContestantDto
    {
        public const string separator = ",";

        public WinnerDto(ContestantDto winningContestant, PrizeDto prize)
        {
            Id = winningContestant.Id;
            Name = winningContestant.Name;
            Email = winningContestant.Email;
            ParticipationDate = winningContestant.ParticipationDate;
            PrizeName = prize.Name;
        }

        public WinnerDto()
        {
            Id = 0;
            Name = string.Empty;
            Email = string.Empty;
            ParticipationDate = DateTime.MinValue;
            PrizeName = string.Empty;
        }

        public string PrizeName { get; set; }

        /*
            id,name,email,date_participated,prize
            1,Adonis Dibbert Jr.,Mortimer_Kertzmann@shane.biz,2018-05-12 11:19:36,Iphone
            2,Gladyce Bergstrom,Meda@carmine.biz,2018-05-12 06:24:22,Mac
        */
        internal new static WinnerDto FromCsvLine(string csvLine)
        {
            string[] values = csvLine.Split(',');

            return new WinnerDto()
            {
                Id = Convert.ToUInt32(values[0]),
                Name = values[1],
                Email = values[2],
                ParticipationDate = Convert.ToDateTime(values[3]),
                PrizeName = values[4]
            };
        }

        internal static string ToCsvLine(WinnerDto winner) =>
                winner.Id + separator +
                winner.Name + separator +
                winner.Email + separator +
                winner.ParticipationDate.ToString() + separator +
                winner.PrizeName + Environment.NewLine;
    }
}
