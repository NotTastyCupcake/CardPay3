using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces;
using Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces.Builder;
using Metcom.CardPay3.ApplicationCore.Specifications;
using System;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Services
{
    public class EmployeService : IEmployeService
    {
        private readonly IAppLogger<EmployeService> _logger;
        private readonly IRepository<Employe> _employeRepository;
        private readonly IRepository<Gender> _genderRepository;
        private readonly IRepository<DocumentItem> _documentRepository;
        private readonly IRepository<RequisitesItem> _requisitesRepository;
        private readonly IRepository<Address> _addressRepository;
        private readonly IEmployeBuilder _builder;

        public Employe _employe;

        public EmployeService(IAppLogger<EmployeService> logger,
            IRepository<Employe> employeRepository,
            IRepository<Gender> genderRepository,
            IRepository<DocumentItem> documentRepository,
            IRepository<RequisitesItem> requisitesRepository,
            IRepository<Address> addressRepository,
            IEmployeBuilder builder)
        {
            _logger = logger;
            _employeRepository = employeRepository;
            _genderRepository = genderRepository;
            _documentRepository = documentRepository;
            _requisitesRepository = requisitesRepository;
            _addressRepository = addressRepository;
            _builder = builder;
        }

        //Создание сотрудника и сохранения его в базе данных с связанными объектами
        public async Task CreateEmploye(
            string lastName, string firstName, string middleName,
            string phoneNum, string jobPhoneNum,
            string position, string departmentNum,
            int idGender,

            int idTypeDocument,
            DateTime dataIssuedDocument,
            string issuedByDocument,
            string subdivisionCodeDocument,

            int organizationId)
        {

            var genderSpec = new EmployeGenderSpecification(idGender);
            var gender = await _genderRepository.SingleOrDefaultAsync(genderSpec);

            if (gender == null)
            {
                throw new Exception("Unknow gender");
            }

            //FIXME: Падает в ошибка при создаании документа 
            var documentSpec = new DocumentItemSpecification(issuedByDocument, subdivisionCodeDocument, idTypeDocument, dataIssuedDocument);
            var document = await _documentRepository.SingleOrDefaultAsync(documentSpec);
            if (document == null)
            {
                document = new DocumentItem(idTypeDocument, dataIssuedDocument, issuedByDocument, subdivisionCodeDocument);
                await _documentRepository.AddAsync(document);
            }

            _builder.CreateEmploye(lastName, firstName, middleName, phoneNum, jobPhoneNum, position, departmentNum, gender, document, organizationId);
            _employe = _builder.GetEmploye();
            await _employeRepository.AddAsync(_employe);
        }

        public async Task AddAddress(string country, int postcode, string state, string district, string city, string locality, string streetType, string street, int numHome, int numCase, int numApartment)
        {
            _builder.SetAddress(new Address(country, postcode, state, district, city, locality, streetType, street, numHome, numCase, numApartment, _employe.Id));
        }

        public Employe GetEmploye()
        {
            return _employe;
        }
    }
}
