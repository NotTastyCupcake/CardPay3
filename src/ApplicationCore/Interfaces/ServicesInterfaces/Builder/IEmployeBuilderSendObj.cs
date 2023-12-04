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
    public interface IEmployeBuilderSendObj
    {
        public Task<IEmployeBuilder> SetGender(Gender gender);
        public Task<IEmployeBuilder> SetOrganization(Organization organization);
        public Task<IEmployeBuilder> SetDocument(IDocumentItem document);
        public Task<IEmployeBuilder> SetRequisites(IRequisitesItem employeRequisites);
        public Task<IEmployeBuilder> SetAddress(IAddress employeAddress);
        public Task<IEmployeBuilder> SetEmploye(IEmploye employe);
        public Task<Employe> GetEmploye();
    }
}
