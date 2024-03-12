using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.WpfApplication.ViewModels.Employes.RequisitiesCRUD;
using Microsoft.Extensions.Logging;
using ReactiveUI.Validation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.ViewModels.Employes.AddressCRUD
{
    public class AddressViewModel : ReactiveValidationObject
    {
        protected readonly IRepository<Address> _addressRepository;
        protected readonly ILogger<AddressViewModel> _logger;

        protected readonly IObservable<bool> IsValid;


        public AddressViewModel(
            IRepository<Address> addressRepository,
            ILogger<AddressViewModel> logger)
        {

            _addressRepository = addressRepository;
            _logger = logger;


        }
    }
}
