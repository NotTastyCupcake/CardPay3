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

        public async Task LoadAddress(Employee employee)
        {
            //var addressSpec = new AddressSpecification(employee);
            //var addresses = await _repository.ListAsync(addressSpec);
            //Addresses.AddOrUpdate(addresses);
        }

        public SourceCache<Address, int> Addresses { get; } = new SourceCache<Address, int>(e => e.Id);
    }
}
