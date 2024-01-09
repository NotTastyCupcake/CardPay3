using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using System;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces.Builder
{
    public interface IEmployeeBuilder : IEmployeeBuilderSendField, IEmployeeBuilderSendObj
    {
        public Task<IEmployeeBuilder> SetGender(int idGender);
        public Task<IEmployeeBuilder> SetOrganization(int organizationId);
    }
}
