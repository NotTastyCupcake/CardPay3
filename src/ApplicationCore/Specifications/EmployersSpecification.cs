using Ardalis.Specification;
using Metcom.CardPay3.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Specifications
{
    public sealed class EmployersSpecification : Specification<Employer>, ISingleResultSpecification<Employer>
    {
        public EmployersSpecification(params int[] ids)
        {
            Query.Where(c => ids.Contains(c.Id));
        }

        public EmployersSpecification(int? organizationId)
        {
            Query.Where(p => (!organizationId.HasValue || p.IdOrganization == organizationId));
        }
    }
}
