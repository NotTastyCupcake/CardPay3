using Metcom.CardPay3.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces.Builder
{
    public interface IEmployeBuilderSendField
    {
        public Task<IEmployeBuilder> SetGender(int idGender);
        public Task<IEmployeBuilder> SetOrganization(int organizationId);
        public Task<IEmployeBuilder> SetDocument(int idType,
                                                string series,
                                                string number,
                                                DateTime dataIssued,
                                                string issuedBy,
                                                string subdivisionCode);
        public Task<IEmployeBuilder> SetRequisities(int inn,
                                                    string insuranceNum,
                                                    int idDivision,
                                                    int idCurrency,
                                                    int idCardType,
                                                    int idEmployer,

                                                    string latinFirstName = null,
                                                    string latinLastName = null);

        public Task<IEmployeBuilder> SetAddress(int idCountry,
                                                int postcode,
                                                int idState,
                                                string district,
                                                int idCity,
                                                int idLocality,
                                                string streetType,
                                                int idStreet,
                                                int numHome,
                                                int numCase,
                                                int numApartment,
                                                int idEmployer);

        public Task<IEmployeBuilder> SetEmploye(string lastName,
                                                string firstName,
                                                string middleName,
                                                string phoneNum,
                                                string jobPhoneNum,
                                                string position,
                                                string departmentNum);
        public Task<Employe> GetEmploye();
    }
}
