using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Entities
{
    public class PersonOrganization : BaseEntity
    {
        public string Name { get; private set; }
        public PersonOrganization(string name)
        {
            Name = name;
        }

        public void UpdateNameGroup(string newNameOrganization)
        {
            Guard.Against.NullOrEmpty(newNameOrganization, nameof(newNameOrganization));

            Name = newNameOrganization;
        }
    }
}
