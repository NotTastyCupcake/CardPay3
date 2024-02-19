using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.WpfApplication.Interfaces;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.Services
{
    public class EmployeeViewModelService : ReactiveObject, IEmployeeViewModelService
    {
        private readonly ILogger<EmployeeViewModelService> _logger;

        private readonly IRepository<Organization> _organizationRepository;
        private readonly IRepository<Gender> _genderRepository;
        private readonly IRepository<DocumentType> _documentTypeRepository;
        private readonly IRepository<Address> _addressRepository;

        public EmployeeViewModelService(
            IRepository<Employee> itemRepository,
            IRepository<Organization> organizationRepository,
            IRepository<Gender> genderRepository,
            IRepository<DocumentType> documentTypeRepository,
            IRepository<Address> addressRepository,
            ILogger<EmployeeViewModelService> logger)
        {
            _organizationRepository = organizationRepository;
            _documentTypeRepository = documentTypeRepository;
            _genderRepository = genderRepository;
            _addressRepository = addressRepository;

            _logger = logger;
        }


        public async Task<ReadOnlyObservableCollection<Gender>> GetGenders()
        {
            _logger.LogInformation("GetGenders called.");

            var employes = await _genderRepository.ListAsync();
            var items = new ObservableCollection<Gender>(employes);

            return new ReadOnlyObservableCollection<Gender>(items);
        }

        public ObservableCollection<Address> GetAddress(Employee employee)
        {
            //TODO: Переделать получение адресов
            //_logger.LogInformation("GetGenders called.");

            //var employes = employee.Addresses;
            //var items = new ObservableCollection<Address>(employes);

            //return items;
            return null;
        }
    }
}
