using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.WpfApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.Services
{
    public class AddressViewModelService : IAddressViewModelService
    {
        private readonly IRepository<AddressType> _typeRepository;
        public AddressViewModelService(IRepository<AddressType> typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<ReadOnlyCollection<AddressType>> GetAddressTypeAsync()
        {
            var types = await _typeRepository.ListAsync();

            return new ReadOnlyCollection<AddressType>(types);
        }

    }
}
