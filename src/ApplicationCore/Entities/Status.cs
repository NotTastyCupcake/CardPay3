using System;
using System.Collections.Generic;
using System.Text;

namespace Metcom.CardPay3.ApplicationCore.Entities
{
    public class Status : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Status(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
