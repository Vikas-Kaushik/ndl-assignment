using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contest.Models
{
    public class PrizeDto
    {
        public uint Id { get; set; }

        public string Name { get; set; }

        public DateTime UnlockedDate { get; set; }

        //id,name,date_unlocked
        //1,iPhone X,2018-05-12 14:30:00
        internal static PrizeDto FromCsvLine(string csvLine)
        {
            string[] values = csvLine.Split(',');

            return new PrizeDto()
            {
                Id = Convert.ToUInt32(values[0]),
                Name = values[1],
                UnlockedDate = Convert.ToDateTime(values[2])
            };
        }
    }
}
