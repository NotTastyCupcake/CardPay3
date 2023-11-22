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
    public class EmployeViewModelService : ReactiveObject, IEmployeViewModelService
    {
        private readonly ILogger<EmployeViewModelService> _logger;

        private readonly IRepository<Organization> _organizationRepository;
        private readonly IRepository<Gender> _genderRepository;
        private readonly IRepository<DocumentType> _documentTypeRepository;
        private readonly IRepository<Address> _addressRepository;

        public EmployeViewModelService(
            IRepository<Employe> itemRepository,
            IRepository<Organization> organizationRepository,
            IRepository<Gender> genderRepository,
            IRepository<DocumentType> documentTypeRepository,
            IRepository<Address> addressRepository,
            ILogger<EmployeViewModelService> logger)
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

        public ObservableCollection<Address> GetAddress(Employe employe)
        {
            _logger.LogInformation("GetGenders called.");

            var employes = employe.Addresses;
            var items = new ObservableCollection<Address>(employes);

            return items;
        }

        public ObservableCollection<RequisitesItem> GetRequisites(Employe employe)
        {
            _logger.LogInformation("GetGenders called.");

            var employes = employe.Requisites;
            var items = new ObservableCollection<RequisitesItem>(employes);

            return items;
        }
    }
}
