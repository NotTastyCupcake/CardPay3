using Ardalis.Specification;
using Metcom.CardPay3.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Specifications
{
    public class PersonItemNameFilterSpecification : Specification<PersonItem>
    {
        public PersonItemNameFilterSpecification(string personFirstName = "", string personLastName = "", string personMiddleName = "")
        {
            Query.Where(item =>
            item.FirstName.Contains(personFirstName)
            || item.LastName.Contains(personLastName) 
            || item.MiddleName.Contains(personMiddleName));
        }
    }
}
