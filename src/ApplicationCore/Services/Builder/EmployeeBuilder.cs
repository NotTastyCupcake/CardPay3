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
        private ICollection<Address> _addressCollection;

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

        public async Task<IEmployeeBuilder> SetGender(int idGender)
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


        public async Task<IEmployeeBuilder> SetDocument(DocumentItem document)
        {

            _document = document;

            if (_employee != null)
            {
                _employee.Document = _document;
                await _employeRepository.UpdateAsync(_employee);
                await _employeRepository.SaveChangesAsync();
            }
            else
            {
                await _documentRepository.AddAsync(document);
                await _documentRepository.SaveChangesAsync();
            }

            return this;
        }

        public async Task<IEmployeeBuilder> SetRequisities(RequisitesItem requisites)
        {

            _requisites = requisites;

            if (_employee != null)
            {
                _employee.Requisite = _requisites;
                await _employeRepository.UpdateAsync(_employee);
                await _employeRepository.SaveChangesAsync();
            }
            else
            {
                await _requisitesRepository.AddAsync(requisites);
                await _requisitesRepository.SaveChangesAsync();
            }
            

            return this;
        }

        public async Task<IEmployeeBuilder> AddAddress(Address address)
        {
            if (_addressCollection == null)
            {
                _addressCollection = new List<Address>();
            }

            _addressCollection.Add(address);

            if (_employee != null)
            {
                if (_employee.Addresses == null)
                {
                    _employee.Addresses = new List<Address>();
                }

                _employee.Addresses.Add(address);
                await _employeRepository.UpdateAsync(_employee);
                await _employeRepository.SaveChangesAsync();
            }

            return this;
        }

        public async Task<IEmployeeBuilder> SetEmployee(Employee employee)
        {
            if (_requisites != null)
            {
                employee.Requisite = _requisites;
            }

            if (_addressCollection != null)
            {
                employee.Addresses = _addressCollection;
            }

            if (_document != null)
            {
                employee.Document = _document;
            }

            if (_organization != null)
            {
                employee.Organization = _organization;
            }

            if (_gender != null)
            {
                employee.Gender = _gender;
            }


            _employee = employee;

            await _employeRepository.AddAsync(employee);

            await _employeRepository.SaveChangesAsync();

            return this;
        }

        public Employee GetEmployee()
        {
            return _employee;
        }

    }
}
