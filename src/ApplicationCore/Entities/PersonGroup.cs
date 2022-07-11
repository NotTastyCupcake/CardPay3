using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;

namespace Metcom.CardPay3.ApplicationCore.Entities
{
    public class PersonGroup : BaseEntity
    {
        public string Name { get; private set; }

        public ICollection<PersonItem> People { get; private set; }

        public int IdOrganization { get; set; }
        public PersonOrganization Organization { get; set; }

        public PersonGroup(int groupId, string nameGroup)
        {
            Id = groupId;
            Name = nameGroup;
        }

        public void UpdateNameGroup(string newNameGroup)
        {
            Guard.Against.NullOrEmpty(newNameGroup, nameof(newNameGroup));

            Name = newNameGroup;
        }
    }
}
