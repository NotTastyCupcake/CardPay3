using Ardalis.Specification;
using Metcom.CardPay3.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Specifications
{
    public class OrganizationSpecification : Specification<Organization>
    {
        public OrganizationSpecification(int idOrganization)
        {
            Query
                .Where(a => a.Id == idOrganization);
        }

    }
}
