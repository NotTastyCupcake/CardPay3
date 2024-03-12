using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using System;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces.Builder
{
    public interface IEmployeeBuilder
    {
        public Task<IEmployeeBuilder> SetDocument(DocumentItem document);
        public Task<IEmployeeBuilder> SetRequisities(RequisitesItem requisites);
        public Task<IEmployeeBuilder> AddAddress(Address address);
        public Task<IEmployeeBuilder> SetEmployee(Employee employee);
        public Task<IEmployeeBuilder> SetGender(int idGender);
        public Task<IEmployeeBuilder> SetOrganization(int organizationId);

        public Employee GetEmployee();
    }
}
