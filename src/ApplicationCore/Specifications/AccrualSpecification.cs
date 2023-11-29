using Ardalis.Specification;
using Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate;
using System.Linq;

namespace Metcom.CardPay3.ApplicationCore.Specifications
{
    public sealed class AccrualSpecification : Specification<Accrual>, ISingleResultSpecification<Accrual>
    {
        public AccrualSpecification(int idAccrual)
        {
            Query
                .Where(a => a.Id == idAccrual)
                .Include(a => a.Items);
        }

        public AccrualSpecification(string idOrganization)
        {
            Query
                .Where(a => a.IdOrganization == int.Parse(idOrganization))
                .Include(b => b.Items);
        }
    }
}
