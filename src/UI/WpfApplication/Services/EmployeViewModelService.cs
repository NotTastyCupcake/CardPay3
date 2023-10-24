using DynamicData;
using DynamicData.Binding;
using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.ApplicationCore.Specifications;
using Metcom.CardPay3.Infrastructure.Identity;
using Metcom.CardPay3.WpfApplication.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.Services
{
    public class EmployeViewModelService : IEmployeViewModelService
    {
        private readonly ILogger<EmployeViewModelService> _logger;

        private readonly IRepository<Employe> _itemRepository;
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
            _itemRepository = itemRepository;
            _organizationRepository = organizationRepository;
            _documentTypeRepository = documentTypeRepository;
            _genderRepository = genderRepository;
            _addressRepository = addressRepository;

            _logger = logger;
        }

        public async Task<IObservable<IChangeSet<Employe>>> GetEmployes(int? organizationId)
        {
            _logger.LogInformation("GetEmployes called.");

            var filterSpecification = new EmployesSpecification(organizationId);
            var employes = await _itemRepository.ListAsync(filterSpecification);
            var items = new SourceList<Employe>();
            items.AddRange(employes);

            return items.Connect();
        }

        public async Task<IObservable<IChangeSet<Employe>>> GetEmployes()
        {
            _logger.LogInformation("GetEmployes called.");

            var employes = await _itemRepository.ListAsync();
            var items = new SourceList<Employe>();
            items.AddRange(employes);

            return items.Connect();
        }


        public async Task<ReadOnlyObservableCollection<Gender>> GetGenders()
        {
            _logger.LogInformation("GetGenders called.");

            var employes = await _genderRepository.ListAsync();
            var items = new ObservableCollection<Gender>(employes);

            return new ReadOnlyObservableCollection<Gender>(items);
        }

        public async Task<ObservableCollection<Address>> GetAddress(Employe employe)
        {
            _logger.LogInformation("GetGenders called.");

            var employes = employe.Addresses;
            var items = new ObservableCollection<Address>(employes);

            return items;
        }

        public async Task<ObservableCollection<RequisitesItem>> GetRequisites(Employe employe)
        {
            _logger.LogInformation("GetGenders called.");

            var employes = employe.Requisites;
            var items = new ObservableCollection<RequisitesItem>(employes);

            return items;
        }
    }
}
