using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces.Builder
{
    public interface IEmployeBuilder
    {
        public void CreateEmploye(
            string lastName,
            string firstName,
            string middleName,
            string phoneNum,
            string jobPhoneNum,
            string position,
            string departmentNum,
            Gender employeGender,
            DocumentItem employeDocument,
            int organizationId);
        public void SetRequisites(RequisitesItem employeRequisites);
        public void SetAddress(Address employeAddress);
        public Employe GetEmploye();
    }
}
