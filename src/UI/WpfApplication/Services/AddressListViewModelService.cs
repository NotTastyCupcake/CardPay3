using Castle.Core.Logging;
using DynamicData;
using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.ApplicationCore.Specifications;
using Metcom.CardPay3.WpfApplication.Interfaces;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.Services
{
    public class AddressListViewModelService : ReactiveObject, IAddressListViewModelService
    {
        private readonly ILogger<AddressListViewModelService> _logger;
        private readonly IRepository<Address> _repository;

        public AddressListViewModelService(IRepository<Address> repository, 
            ILogger<AddressListViewModelService> logger)
        {
            _logger = logger;
            _repository = repository;

        }

        public async Task<SourceCache<Address, int>> GetAddressByEmployee(Employee employee)
        {
            // Load the initial data from the database
            LoadAddress(employee);

            // Subscribe to the changes in the database every 5 seconds
            Observable.Interval(TimeSpan.FromSeconds(5), RxApp.TaskpoolScheduler)
                .SelectMany(async _ => await _repository.ListAsync(new AddressSpecification(employee)))
                .Subscribe(employees =>
                {
                    // Update the source cache with the latest data
                    Addresses.Edit(innerList =>
                    {
                        innerList.Clear();
                        innerList.AddOrUpdate(employees);
                    });
                });

            return Addresses;
        }

        private async void LoadAddress(Employee employee)
        {
            var addressSpec = new AddressSpecification(employee);
            var addresses = await _repository.ListAsync(addressSpec);
            Addresses.AddOrUpdate(addresses);
        }

        private SourceCache<Address, int> Addresses { get; } = new SourceCache<Address, int>(e => e.Id);
    }
}
