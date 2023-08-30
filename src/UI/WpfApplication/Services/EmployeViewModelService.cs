using DynamicData;
using DynamicData.Binding;
using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
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

        public EmployeViewModelService(
            IRepository<Employe> itemRepository,
            IRepository<Organization> organizationRepository,
            IRepository<Gender> genderRepository,
            IRepository<DocumentType> documentTypeRepository,
            ILogger<EmployeViewModelService> logger)
        {
            _itemRepository = itemRepository;
            _organizationRepository = organizationRepository;
            _documentTypeRepository = documentTypeRepository;
            _genderRepository = genderRepository;

            _logger = logger;
        }

        public async Task<IObservableCache<Employe, int>> GetEmployes(int? organizationId)
        {
            _logger.LogInformation("GetEmployes called.");

            var filterSpecification = new EmployesSpecification(organizationId);
            var employes = await _itemRepository.ListAsync(filterSpecification);
            var items = new ObservableCollection<Employe>(employes);

            return items.ToObservableChangeSet(t => t.Id).AsObservableCache();
        }
    }
}
