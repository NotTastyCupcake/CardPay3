using Ardalis.Specification;
using Metcom.CardPay3.ApplicationCore.Entities;
using System;
using System.Linq;

namespace Metcom.CardPay3.ApplicationCore.Specifications
{
    public sealed class EmployesSpecification : Specification<Employe>, ISingleResultSpecification<Employe>
    {
        public EmployesSpecification(params int[] ids)
        {
            Query.Where(c => ids.Contains(c.Id));
        }

        public EmployesSpecification(int? organizationId)
        {
            Query.Where(p => (!organizationId.HasValue || p.IdOrganization == organizationId));
        }
    }
}
