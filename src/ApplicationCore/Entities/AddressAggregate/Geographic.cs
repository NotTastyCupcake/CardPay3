using System;
using System.Collections.Generic;
using System.Text;

namespace Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate
{
    public class Geographic
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int? Code { get; set; }

        public Geographic(string name, string shortName, int? code = null)
        {
            Name = name;
            ShortName = shortName;
            Code = code;
        }
    }
}
