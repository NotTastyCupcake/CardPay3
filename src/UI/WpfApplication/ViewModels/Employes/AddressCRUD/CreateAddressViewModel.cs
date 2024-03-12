using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.ViewModels.Employes.AddressCRUD
{
    public class CreateAddressViewModel : AddressViewModel, IRoutableViewModel
    {
        public string UrlPathSegment { get { return "CreateDocument"; } }
        public IScreen HostScreen { get; protected set; }

        public CreateAddressViewModel(
            IRepository<Address> addressRepository,
            ILogger<AddressViewModel> logger,
            IScreen screen = null) : base(addressRepository, logger)
        {
            HostScreen = screen;
        }



    }
}
