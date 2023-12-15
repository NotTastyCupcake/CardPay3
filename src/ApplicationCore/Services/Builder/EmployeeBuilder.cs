using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces.Builder;
using Metcom.CardPay3.ApplicationCore.Specifications;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Services.Builder
{
    public class EmployeeBuilder : IEmployeeBuilder
    {
        private readonly IRepository<Employee> _employeRepository;
        private readonly IRepository<Gender> _genderRepository;
        private readonly IRepository<DocumentItem> _documentRepository;
        private readonly IRepository<RequisitesItem> _requisitesRepository;
        private readonly IRepository<Address> _addressRepository;
        private readonly IRepository<Organization> _organizationRepository;
        private readonly IAppLogger<EmployeeBuilder> _logger;

        private Employee _employee;
        private Gender _gender;
        private DocumentItem _document;
        private Organization _organization;
        private RequisitesItem _requisites;
        private Address _address;

        public EmployeeBuilder(IRepository<Employee> employeRepository,
            IRepository<Gender> genderRepository,
            IRepository<DocumentItem> documentRepository,
            IRepository<RequisitesItem> requisitesRepository,
            IRepository<Address> addressRepository,
            IRepository<Organization> organizationRepository, 
            IAppLogger<EmployeeBuilder> logger)
        {

            _employeRepository = employeRepository;
            _genderRepository = genderRepository;
            _documentRepository = documentRepository;
            _requisitesRepository = requisitesRepository;
            _addressRepository = addressRepository;
            _organizationRepository = organizationRepository;

            _logger = logger; 
        }

        //public async Task<IEmployeBuilder> SetGender(int idGender)
        //{
        //    var genderSpec = new EmployeGenderSpecification(idGender);
        //    var gender = await _genderRepository.SingleOrDefaultAsync(genderSpec);

        //    if (gender == null)
        //    {
        //        throw new Exception("Unknow gender");
        //    }

        //    _gender = gender;
        //    return this;
        //}

        //public async Task<IEmployeBuilder> SetDocument(
        //                    int idType,
        //                    string series,
        //                    string number,
        //                    DateTime dataIssued,
        //                    string issuedBy,
        //                    string subdivisionCode)
        //{

        //    var documentSpec = new DocumentItemSpecification(series,
        //                                                     number,
        //                                                     idType,
        //                                                     dataIssued);

        //    var document = await _documentRepository.SingleOrDefaultAsync(documentSpec);
        //    if (document == null)
        //    {
        //        document = new DocumentItem(idType,
        //                                    series,
        //                                    number,
        //                                    dataIssued,
        //                                    issuedBy,
        //                                    subdivisionCode);

        //        await _documentRepository.AddAsync(document);
        //    }

        //    _document = document;
        //    return this;
        //}

        //public async Task<IEmployeBuilder> SetOrganization(int organizationId)
        //{
        //    var organization = await _organizationRepository.GetByIdAsync(organizationId);
        //    _organization = organization;
        //    return this;
        //}

        ////TODO: Создание реквезитов
        //public async Task<IEmployeBuilder> SetRequisites(RequisitesItem employeRequisites)
        //{
        //    _requisites = employeRequisites;
        //    return this;
        //}
        ////TODO: Создание аддреса
        //public async Task<IEmployeBuilder> SetAddress(Address employeAddress)
        //{
        //    _address = employeAddress;
        //    return this;
        //}

        //public async Task<IEmployeBuilder> SetDocument(IDocumentItem document)
        //{
        //    return await this.SetDocument(document.IdType, 
        //                                  document.Series, 
        //                                  document.Number, 
        //                                  document.DataIssued, 
        //                                  document.IssuedBy, 
        //                                  document.SubdivisionCode);
        //}

        //public Task<IEmployeBuilder> SetRequisites(IRequisitesItem employeRequisites)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEmployeBuilder> SetAddress(IAddress employeAddress)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEmployeBuilder> SetEmploye(string lastName, string firstName, string middleName, string phoneNum, string jobPhoneNum, string position, string departmentNum)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEmployeBuilder> SetEmploye(IEmploye employe)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Employe> GetEmploye()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEmployeBuilder> SetRequisities(int inn, string insuranceNum, int idDivision, int idCurrency, int idCardType, int idEmployer, string latinFirstName = null, string latinLastName = null)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEmployeBuilder> SetGender(Gender gender)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEmployeBuilder> SetOrganization(Organization organization)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
