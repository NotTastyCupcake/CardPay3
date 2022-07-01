using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Entities
{
    public class PersonGender : BaseEntity
    {
        public string GenderName { get; private set; }
        public string ShortGenderName { get; private set; }

        public PersonGender(int genderId, string name, string shortName)
        {
            Id = genderId;
            GenderName = name;
            ShortGenderName = shortName;
        }
    }
}
