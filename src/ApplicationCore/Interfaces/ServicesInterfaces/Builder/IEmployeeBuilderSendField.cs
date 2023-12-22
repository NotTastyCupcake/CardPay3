using Metcom.CardPay3.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces.Builder
{
    public interface IEmployeeBuilderSendField
    {
        public Task<IEmployeeBuilder> SetGender(int idGender);
        public Task<IEmployeeBuilder> SetOrganization(int organizationId);
        public Task<IEmployeeBuilder> SetDocument(int idType,
                                                string series,
                                                string number,
                                                DateTime dataIssued,
                                                string issuedBy,
                                                string subdivisionCode);
        public Task<IEmployeeBuilder> SetRequisities(int inn,
                                                    string insuranceNum,
                                                    int idDivision,
                                                    int idCurrency,
                                                    int idCardType,

                                                    string latinFirstName = null,
                                                    string latinLastName = null);

        public Task<IEmployeeBuilder> SetLegalAddress(int idCountry,
                                                    int postcode,
                                                    int idState,
                                                    string district,
                                                    int idCity,
                                                    int idLocality,
                                                    string streetType,
                                                    int idStreet,
                                                    int numHome,
                                                    int numCase,
                                                    int numApartment);

        public Task<IEmployeeBuilder> SetEmployee(string lastName,
                                                string firstName,
                                                string middleName,
                                                DateTime birthdayDate,
                                                string nationality,
                                                bool resident,
                                                string phoneNum,
                                                string jobPhoneNum,
                                                string position,
                                                string departmentNum);
        public Employee GetEmployee();
    }
}
