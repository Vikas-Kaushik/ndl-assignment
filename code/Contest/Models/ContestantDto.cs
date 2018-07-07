using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contest.Models
{
    public class ContestantDto : IEquatable<ContestantDto>
    {
        public uint Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime ParticipationDate { get; set; }

        /*
            id,name,email,date_participated
            1,Adonis Dibbert Jr.,Mortimer_Kertzmann@shane.biz,2018-05-12 11:19:36
            2,Gladyce Bergstrom,Meda@carmine.biz,2018-05-12 06:24:22
        */
        internal static ContestantDto FromCsvLine(string csvLine)
        {
            string[] values = csvLine.Split(',');

            return new ContestantDto()
            {
                Id = Convert.ToUInt32(values[0]),
                Name = values[1],
                Email = values[2],
                ParticipationDate = Convert.ToDateTime(values[3])
            };
        }

        public bool Equals(ContestantDto other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Email.Equals(other.Email, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = (int)2166136261;

                var email = Email?.ToLower() ?? string.Empty;

                hash = (hash * 16777619) ^ email.GetHashCode();

                return hash;
            }
        }
    }
}
