using Castle.Core.Logging;
using DynamicData;
using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.WpfApplication.Interfaces;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.Services
{
    public class HomeViewModelService :ReactiveObject , IHomeViewModelService
    {
        private readonly ILogger<HomeViewModelService> _logger;
        private readonly IRepository<Organization> _organizationRepository;

        public HomeViewModelService(ILogger<HomeViewModelService> logger, IRepository<Organization> organizationRepository)
        {
            _logger = logger;

            _organizationRepository = organizationRepository;
        }
        public async Task<ObservableCollection<Organization>> GetOrganizations()
        {
            _logger.LogInformation("GetOrganizations called.");
            var organizations = await _organizationRepository.ListAsync();

            var items = new ObservableCollection<Organization>(organizations)
            {
                new Organization("Создать организацию.")
            };

            return items;
        }
    }
}
