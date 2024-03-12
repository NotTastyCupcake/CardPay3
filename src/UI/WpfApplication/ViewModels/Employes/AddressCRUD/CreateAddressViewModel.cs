using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.WpfApplication.Interfaces;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.ViewModels.Employes.AddressCRUD
{
    public class CreateAddressViewModel : AddressViewModel, IRoutableViewModel
    {
        public string UrlPathSegment { get { return "CreateDocument"; } }
        public IScreen HostScreen { get; protected set; }

        public CreateAddressViewModel(
            IAddressViewModelService service,
            ILogger<AddressViewModel> logger,
            IScreen screen = null) : base(service, logger)
        {
            HostScreen = screen;

            CtreateCommand = ReactiveCommand.CreateFromTask(async () => 
            {
                Address = new Address()
                {
                    Postcode = Postcode,
                    Country = new Geographic(CountryName, CountryShortName, CountryCode),
                    State = string.IsNullOrEmpty(LocalityName) ? null : new Geographic(StateName, ""),
                    District = District,
                    City = string.IsNullOrEmpty(CityName) ? null : new Geographic(CityName, ""),
                    Locality = string.IsNullOrEmpty(LocalityName) ? null : new Geographic(LocalityName, ""),
                    StreetType = StreetType,
                    Street = new Geographic(StateName, ""),
                    NumHome = NumHome ?? null,
                    NumCase = NumCase ?? null,
                    NumApartment = NumApartment ?? null,
                    Type = SelectedType,
                    IdType = SelectedType.Id
                };

                await HostScreen.Router.NavigateBack.Execute();
            });

        }

        public ReactiveCommand<Unit, Unit> CtreateCommand { get; set; }

    }
}
