using Ardalis.Specification;
using Metcom.CardPay3.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Specifications
{
    public sealed class EmployerNameFilterSpecification : Specification<Employer>, ISingleResultSpecification<Employer>
    {
        public EmployerNameFilterSpecification(string employerFirstName = "", string employerLastName = "", string employerMiddleName = "")
        {
            Query.Where(item =>
            item.FirstName.Contains(employerFirstName)
            || item.LastName.Contains(employerLastName) 
            || item.MiddleName.Contains(employerMiddleName));
        }
    }
}
