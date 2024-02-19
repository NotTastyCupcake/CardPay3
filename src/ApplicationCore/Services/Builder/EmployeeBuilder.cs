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
using System.Runtime.CompilerServices;
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
        private Address _legalAddress;

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

        #region IEmployeeBuilderSendField

        public  async Task<IEmployeeBuilder> SetGender(int idGender)
        {
            var gender = await _genderRepository.GetByIdAsync(idGender);

            if (gender == null)
            {
                throw new Exception("Unknow gender");
            }

            _gender = gender;


            if (_employee != null)
            {
                _employee.Gender = _gender;
                await _employeRepository.UpdateAsync(_employee);
                await _employeRepository.SaveChangesAsync();
            }

            return this;
        }

        async Task<IEmployeeBuilder> IEmployeeBuilderSendField.SetDocument(
                            int idType,
                            string series,
                            string number,
                            DateTime dataIssued,
                            string issuedBy,
                            string subdivisionCode)
        {

            var documentSpec = new DocumentItemSpecification(series,
                                                             number,
                                                             idType,
                                                             dataIssued);
            //поиск дублей
            var document = await _documentRepository.SingleOrDefaultAsync(documentSpec);

            //если схожый объект не найден, сохраняем новый в базу
            if (document == null)
            {
                document = new DocumentItem(idType,
                                            series,
                                            number,
                                            dataIssued,
                                            issuedBy,
                                            subdivisionCode);

                await _documentRepository.AddAsync(document);
                await _documentRepository.SaveChangesAsync();
            }

            _document = document;

            if(_employee != null)
            {
                _employee.Document = document;
                await _employeRepository.UpdateAsync(_employee);
                await _employeRepository.SaveChangesAsync();
            }

            return this;
        }

        public async Task<IEmployeeBuilder> SetOrganization(int organizationId)
        {
            var organization = await _organizationRepository.GetByIdAsync(organizationId);
            _organization = organization;

            if (_employee != null)
            {
                _employee.Organization = organization;
                await _employeRepository.UpdateAsync(_employee);
                await _employeRepository.SaveChangesAsync();
            }

            return this;
        }

        async Task<IEmployeeBuilder> IEmployeeBuilderSendField.SetLegalAddress(int idCountry,
                                                                               int postcode,
                                                                               int idState,
                                                                               string district,
                                                                               int idCity,
                                                                               int idLocality,
                                                                               string streetType,
                                                                               int idStreet,
                                                                               int numHome,
                                                                               int numCase,
                                                                               int numApartment)
        {
            var newAddress = new Address(idCountry, postcode, idState, 
                                         district, idCity, idLocality, 
                                         streetType, idStreet, numHome,
                                         numCase,numApartment);
            //поиск дублей
            var addressSpecification = new AddressSpecification(newAddress);
            var address = await _addressRepository.SingleOrDefaultAsync(addressSpecification);

            //если схожый объект не найден, сохраняем новый в базу
            if (address == null)
            {
                await _addressRepository.AddAsync(newAddress);
                await _addressRepository.SaveChangesAsync();
                _legalAddress = newAddress;
            }
            else
            {
                _legalAddress = address;
            }

            if (_employee != null)
            {
                _employee.Addresses.Add(_legalAddress);
                await _employeRepository.UpdateAsync(_employee);
                await _employeRepository.SaveChangesAsync();
            }

            return this;

        }

        async Task<IEmployeeBuilder> IEmployeeBuilderSendField.SetRequisities(int inn, 
                                                                              string insuranceNum, 
                                                                              int idDivision, 
                                                                              int idCurrency, 
                                                                              int idCardType, 
                                                                              int idStatus,

                                                                              string latinFirstName = null, 
                                                                              string latinLastName = null)
        {
            var newRequisities = new RequisitesItem(inn, insuranceNum, idDivision, idCurrency, idCardType, idStatus, latinFirstName, latinLastName);

            //поиск дублей
            var requisitiesSpecification = new RequisitiesSpecification(newRequisities);
            var requisite = await _requisitesRepository.SingleOrDefaultAsync(requisitiesSpecification);

            //если схожый объект не найден, сохраняем новый в базу
            if (requisite == null)
            {
                await _requisitesRepository.AddAsync(newRequisities);
                await _requisitesRepository.SaveChangesAsync();
                _requisites = newRequisities;
            }
            else
            {
                _requisites = requisite;
            }

            if (_employee != null)
            {
                _employee.Requisite = _requisites;
                await _employeRepository.UpdateAsync(_employee);
                await _employeRepository.SaveChangesAsync();
            }

            return this;

        }

        public async Task<IEmployeeBuilder> SetEmployee(string lastName, 
                                                string firstName, 
                                                string middleName, 
                                                DateTime birthdayDate, 
                                                string nationality, 
                                                bool resident, 
                                                string phoneNum,
                                                string jobPhoneNum, 
                                                string position, 
                                                string departmentNum)
        {
            Employee employee = new Employee(lastName, 
                                            firstName, 
                                            middleName, 
                                            birthdayDate, 
                                            nationality, 
                                            resident, 
                                            phoneNum, 
                                            jobPhoneNum, 
                                            position, 
                                            departmentNum, 
                                            _gender.Id,
                                            _document.Id,
                                            _organization.Id);

            if(employee.Requisite == null && _requisites != null)
            {
                employee.Requisite = _requisites;
            }
            

            if(employee.Addresses == null && _legalAddress != null)
            {
                employee.Addresses = new List<Address>
                {
                    _legalAddress
                };
            }
            

            _employee = employee;

            await _employeRepository.AddAsync(employee);

            await _employeRepository.SaveChangesAsync();

            return this;
        }

        #endregion

        #region IEmployeeBuilderSendObj

        async Task<IEmployeeBuilder> IEmployeeBuilderSendObj.SetDocument(IDocumentItem document)
        {
            var documentSpec = new DocumentItemSpecification(document.Series,
                                                 document.Number,
                                                 document.IdType,
                                                 document.DataIssued);
            //поиск дублей
            var item = await _documentRepository.SingleOrDefaultAsync(documentSpec);

            //если схожый объект не найден, сохраняем новый в базу
            if (item == null)
            {
                item = new DocumentItem(document);

                await _documentRepository.AddAsync(item);
                await _documentRepository.SaveChangesAsync();
            }

            _document = item;

            if (_employee != null)
            {
                _employee.Document = item;
                await _employeRepository.UpdateAsync(_employee);
                await _employeRepository.SaveChangesAsync();
            }


            return this;
        }

        async Task<IEmployeeBuilder> IEmployeeBuilderSendObj.SetRequisites(IRequisitesItem employeRequisites)
        {
            var newRequisities = new RequisitesItem(employeRequisites);

            //поиск дублей
            var requisitiesSpecification = new RequisitiesSpecification(employeRequisites);
            var requisite = await _requisitesRepository.SingleOrDefaultAsync(requisitiesSpecification);

            //если схожый объект не найден, сохраняем новый в базу
            if (requisite == null)
            {
                await _requisitesRepository.AddAsync(newRequisities);
                await _requisitesRepository.SaveChangesAsync();
                _requisites = newRequisities;
                
            }
            else
            {
                _requisites = requisite;
                
            }

            if (_employee != null)
            {
                _employee.Requisite = _requisites;
                await _employeRepository.UpdateAsync(_employee);
                await _employeRepository.SaveChangesAsync();
            }

            return this;
        }

        async Task<IEmployeeBuilder> IEmployeeBuilderSendObj.SetLegalAddress(IAddress employeAddress)
        {
            var newAddress = new Address(employeAddress);
            //поиск дублей
            var addressSpecification = new AddressSpecification(newAddress);
            var address = await _addressRepository.SingleOrDefaultAsync(addressSpecification);

            //если схожый объект не найден, сохраняем новый в базу
            if (address == null)
            {
                await _addressRepository.AddAsync(newAddress);
                await _addressRepository.SaveChangesAsync();
                _legalAddress = newAddress;
            }
            else
            {
                _legalAddress = address;
            }

            if (_employee != null)
            {
                if(_employee.Addresses == null)
                {
                    _employee.Addresses = new List<Address>();
                }

                _employee.Addresses.Add(_legalAddress);
                await _employeRepository.UpdateAsync(_employee);
                await _employeRepository.SaveChangesAsync();
            }

            return this;

        }

        async Task<IEmployeeBuilder> IEmployeeBuilderSendObj.SetEmployee(IEmployee employee)
        {
            Employee item = new Employee(employee);

            if(_requisites != null)
            {
                item.Requisite = _requisites;
            }

            if (item.Addresses == null)
            {
                item.Addresses = new List<Address>();
            }
            if(_legalAddress != null)
            {
                item.Addresses.Add(_legalAddress);
            }


            if(_document != null)
            {
                item.Document = _document;
            }
            if(_organization != null)
            {
                item.Organization = _organization;
            }
            if(_gender != null)
            { 
                item.Gender = _gender;
            }


            _employee = item;

            await _employeRepository.AddAsync(item);

            await _employeRepository.SaveChangesAsync();

            return this;
        }


        #endregion


        public Employee GetEmployee()
        {
            return _employee;
        }
    }
}
