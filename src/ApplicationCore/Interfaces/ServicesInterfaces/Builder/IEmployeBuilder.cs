using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using System;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces.Builder
{
    public interface IEmployeBuilder
    {
        public Task<IEmployeBuilder> SetGender(int idGender);
        public Task<IEmployeBuilder> SetDocument(int idTypeDocument,
            DateTime dataIssuedDocument,
            string issuedByDocument,
            string subdivisionCodeDocument);
        public Task<IEmployeBuilder> SetOrganization(int organizationId);
        public Task<IEmployeBuilder> SetRequisites(RequisitesItem employeRequisites);
        public Task<IEmployeBuilder> SetAddress(Address employeAddress);
        public Task<Employe> GetEmploye(string lastName,
            string firstName,
            string middleName,
            string phoneNum,
            string jobPhoneNum,
            string position,
            string departmentNum);
    }
}
