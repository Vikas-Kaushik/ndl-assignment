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
    }
}
