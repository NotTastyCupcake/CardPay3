using Ardalis.GuardClauses;
using System.Collections.Generic;

namespace Metcom.CardPay3.ApplicationCore.Entities
{
    public class Organization : BaseEntity
    {
        public virtual ICollection<Employe> Employes { get; private set; }
        public string Name { get; private set; }

        public Organization(string name)
        {
            Name = name;
        }


        public Organization()
        {
            // required by EF
        }

        public void UpdateNameGroup(string newNameOrganization)
        {
            Guard.Against.NullOrEmpty(newNameOrganization, nameof(newNameOrganization));

            Name = newNameOrganization;
        }
    }
}
