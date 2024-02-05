using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using ReactiveUI.Validation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.ViewModels.Employes.AddressCRUD
{
    public class AddressViewModel : ReactiveValidationObject, IAddress
    {
        protected readonly IObservable<bool> IsValid;



        public Geographic City { get; set; }

        public Geographic Country { get; set; }

        public string District { get; set; }

        public Employee Employee { get; set; }

        public int IdCity { get; set; }

        public int IdCountry { get; set; }

        public int? IdEmployee { get; set; }

        public int IdLocality { get; set; }

        public int IdState { get; set; }

        public int IdStreet { get; set; }

        public Geographic Locality { get; set; }

        public int NumApartment { get; set; }

        public int NumCase { get; set; }

        public int NumHome { get; set; }

        public int Postcode { get; set; }

        public Geographic State { get; set; }

        public Geographic Street { get; set; }

        public string StreetType { get; set; }
    }
}
