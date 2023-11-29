﻿using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces.Builder;
using Metcom.CardPay3.ApplicationCore.Specifications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Services.Builder
{
    public class EmployeBuilder : IEmployeBuilder
    {
        private readonly IRepository<Employe> _employeRepository;
        private readonly IRepository<Gender> _genderRepository;
        private readonly IRepository<DocumentItem> _documentRepository;
        private readonly IRepository<RequisitesItem> _requisitesRepository;
        private readonly IRepository<Address> _addressRepository;
        private readonly IRepository<Organization> _organizationRepository;
        private readonly IAppLogger<EmployeBuilder> _logger;

        private Employe _employe;
        private Gender _gender;
        private DocumentItem _document;
        private Organization _organization;
        private RequisitesItem _requisites;
        private Address _address;

        public EmployeBuilder(IRepository<Employe> employeRepository,
            IRepository<Gender> genderRepository,
            IRepository<DocumentItem> documentRepository,
            IRepository<RequisitesItem> requisitesRepository,
            IRepository<Address> addressRepository,
            IRepository<Organization> organizationRepository, 
            IAppLogger<EmployeBuilder> logger)
        {

            _employeRepository = employeRepository;
            _genderRepository = genderRepository;
            _documentRepository = documentRepository;
            _requisitesRepository = requisitesRepository;
            _addressRepository = addressRepository;
            _organizationRepository = organizationRepository;

            _logger = logger; 
        }

        public async Task<IEmployeBuilder> SetGender(int idGender)
        {
            var genderSpec = new EmployeGenderSpecification(idGender);
            var gender = await _genderRepository.SingleOrDefaultAsync(genderSpec);

            if (gender == null)
            {
                throw new Exception("Unknow gender");
            }

            _gender = gender;
            return this;
        }

        public async Task<IEmployeBuilder> SetDocument(
            int idTypeDocument,
            DateTime dataIssuedDocument,
            string issuedByDocument,
            string subdivisionCodeDocument)
        {

            var documentSpec = new DocumentItemSpecification(issuedByDocument, 
                                                             subdivisionCodeDocument, 
                                                             idTypeDocument, 
                                                             dataIssuedDocument);

            var document = await _documentRepository.SingleOrDefaultAsync(documentSpec);
            if (document == null)
            {
                document = new DocumentItem(idTypeDocument, 
                                            dataIssuedDocument, 
                                            issuedByDocument, 
                                            subdivisionCodeDocument);

                await _documentRepository.AddAsync(document);
            }

            _document = document;
            return this;
        }

        public async Task<IEmployeBuilder> SetOrganization(int organizationId)
        {
            var organization = await _organizationRepository.GetByIdAsync(organizationId);
            _organization = organization;
            return this;
        }

        //TODO: Создание реквезитов
        public async Task<IEmployeBuilder> SetRequisites(RequisitesItem employeRequisites)
        {
            _requisites = employeRequisites;
            return this;
        }
        //TODO: Создание аддреса
        public async Task<IEmployeBuilder> SetAddress(Address employeAddress)
        {
            _address = employeAddress;
            return this;
        }

        public async Task<Employe> GetEmploye(string lastName, string firstName, string middleName, string phoneNum, string jobPhoneNum, string position, string departmentNum)
        {
            _employe = new Employe(lastName, firstName, middleName, phoneNum, jobPhoneNum,position,departmentNum,_gender.Id, _document.Id, _organization.Id);
            _employe.Addresses.Add(_address);
            _employe.Requisites.Add(_requisites);

            await _employeRepository.AddAsync(_employe);
            await _employeRepository.SaveChangesAsync();

            return _employe;
        }
    }
}
