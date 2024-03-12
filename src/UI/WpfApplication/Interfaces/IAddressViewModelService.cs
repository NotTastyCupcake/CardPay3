using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.Interfaces
{
    public interface IAddressViewModelService
    {
        Task<ReadOnlyCollection<AddressType>> GetAddressTypeAsync();
    }
}
