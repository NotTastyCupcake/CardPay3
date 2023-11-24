using Metcom.CardPay3.ApplicationCore.Entities;
using System;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces
{
    public interface IEmployeService
    {
        public Employe GetEmploye();
        public Task CreateEmploye(string lastName,
            string firstName,
            string middleName,
            string phoneNum,
            string jobPhoneNum,
            string position,
            string departmentNum,
            int idGender,

            int idTypeDocument,
            DateTime dataIssuedDocument,
            string issuedByDocument,
            string subdivisionCodeDocument,

            int organizationId);
        public Task AddAddress(int country,
                               int postcode, 
                               int state, 
                               string district, 
                               int city, 
                               int locality, 
                               string streetType, 
                               int street, 
                               int numHome, 
                               int numCase, 
                               int numApartment);

    }
}
