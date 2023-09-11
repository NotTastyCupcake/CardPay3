using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Services.Builder
{
    public class EmployeBuilder : IEmployeBuilder
    {
        public Employe _employe;

        private readonly IAppLogger<EmployeBuilder> _logger;

        public EmployeBuilder(IAppLogger<EmployeBuilder> logger)
        {
            _logger = logger;
        }

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
            int organizationId)
        {
            _employe = new Employe(lastName, firstName, middleName, phoneNum, jobPhoneNum, position, departmentNum, employeGender.Id, employeDocument.Id, organizationId);
        }

        public void SetAddress(Address employeAddress)
        {
            if(employeAddress == null)
            {
                _logger.LogWarning("Empty Address");
                return;
            }
            _employe.Addresses = new List<Address>
            {
                employeAddress
            };

        }

        public void SetRequisites(RequisitesItem employeRequisites)
        {
            if (employeRequisites == null)
            {
                _logger.LogWarning("Empty Requisites");
                return;
            }
            _employe.Requisites = new List<RequisitesItem>
            {
                employeRequisites
            };
        }

        public Employe GetEmploye()
        {
            return _employe;
        }
    }
}
