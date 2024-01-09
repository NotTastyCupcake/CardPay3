using Ardalis.Specification;
using Metcom.CardPay3.ApplicationCore.Entities;
using System.Linq;

namespace Metcom.CardPay3.ApplicationCore.Specifications
{
    public sealed class EmployerNameFilterSpecification : Specification<Employee>, ISingleResultSpecification<Employee>
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
