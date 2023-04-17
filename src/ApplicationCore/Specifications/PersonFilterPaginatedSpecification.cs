using Ardalis.Specification;
using Metcom.CardPay3.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Specifications
{
    public class PersonFilterPaginatedSpecification : Specification<PersonItem>
    {
        public PersonFilterPaginatedSpecification(int skip, int take, int? organizationId)
            : base()
        {
            if (take == 0)
            {
                take = int.MaxValue;
            }
            Query
                .Where(i => (!organizationId.HasValue || i.IdOrganization == organizationId))
                .Skip(skip).Take(take);
        }
    }
}
