using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using Metcom.CardPay3.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces.Builder
{
    public interface IEmployeeBuilderSendObj
    {
        public Task<IEmployeeBuilder> SetGender(Gender gender);
        public Task<IEmployeeBuilder> SetOrganization(Organization organization);
        public Task<IEmployeeBuilder> SetDocument(IDocumentItem document);
        public Task<IEmployeeBuilder> SetRequisites(IRequisitesItem employeRequisites);
        public Task<IEmployeeBuilder> SetAddress(IAddress employeAddress);
        public Task<IEmployeeBuilder> SetEmployee(IEmployee employee);
        public Task<Employee> GetEmployee();
    }
}
