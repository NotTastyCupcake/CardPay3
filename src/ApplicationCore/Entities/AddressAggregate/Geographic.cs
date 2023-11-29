using System;
using System.Collections.Generic;
using System.Text;

namespace Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate
{
    public class Geographic : BaseEntity
    {
        public string Name { get; private set; }
        public string ShortName { get; private set; }
        public int? Code { get; private set; }

        public Geographic(string name, string shortName, int? code = null)
        {
            Name = name;
            ShortName = shortName;
            Code = code;
        }
    }
}
