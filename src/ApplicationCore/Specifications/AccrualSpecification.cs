using Ardalis.Specification;
using Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Specifications
{
    public sealed class AccrualSpecification : Specification<Accrual>, ISingleResultSpecification<Accrual>
    {
        public AccrualSpecification(string idOrganization)
        {
            Query
                .Where(b => b.OrganizationId == idOrganization)
                .Include(b => b.Items);
        }
        public AccrualSpecification(int idAccrual)
        {
            Query
                .Where(b => b.Id == idAccrual)
                .Include(b => b.Items);
        }
    }
}
