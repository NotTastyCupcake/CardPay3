using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.WpfApplication.Interfaces;
using Metcom.CardPay3.WpfApplication.ViewModels.Employes.RequisitiesCRUD;
using Microsoft.Extensions.Logging;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.ViewModels.Employes.AddressCRUD
{
    public class AddressViewModel : ReactiveValidationObject
    {
        protected readonly ILogger<AddressViewModel> _logger;
        protected readonly IAddressViewModelService _service;

        protected readonly IObservable<bool> IsValid;


        public AddressViewModel(
            IAddressViewModelService service,
            ILogger<AddressViewModel> logger)
        {
            _service = service;
            _logger = logger;

        }

        public async Task InitializeAsync()
        {
            Types = await _service.GetAddressTypeAsync();
        }

        public ReadOnlyCollection<AddressType> Types { get; private set; }

        /// <summary>
        /// Индекс
        /// </summary>
        public int? Postcode { get; set; }

        public string CountryName { get; set; }
        public string CountryShortName { get; set; }
        public int? CountryCode { get; set; }

        public string StateName { get; set; }

        /// <summary>
        /// Район
        /// </summary>
        public string District { get; set; }

        public string CityName { get; set; }

        public string LocalityName { get; set; }

        /// <summary>
        /// Тип улицы
        /// </summary>
        public string StreetType { get; set; }

        public string StreetName { get; set; }

        /// <summary>
        /// Номер дома
        /// </summary>
        public int? NumHome { get; set; }

        /// <summary>
        /// Номер корпуса
        /// </summary>
        public int? NumCase { get; set; }

        /// <summary>
        /// Номер квартиры
        /// </summary>
        public int? NumApartment { get; set; }

        [Reactive]
        public AddressType SelectedType { get; set; }
        [Reactive]
        public Address Address { get; set; }

    }
}
