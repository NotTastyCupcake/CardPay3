using System;
using System.Collections.Generic;
using System.Text;

namespace Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate
{
    public class AddressType : BaseEntity
    {
        public string Name { get; private set; }

        public AddressType(string name) 
        { 
            Name = name; 
        }

    }
}
