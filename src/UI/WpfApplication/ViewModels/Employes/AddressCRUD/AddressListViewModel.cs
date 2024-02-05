using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities;
using System.Collections.ObjectModel;
using DynamicData.Binding;
using Metcom.CardPay3.WpfApplication.Interfaces;
using Splat;
using System.Diagnostics.Metrics;
using DynamicData;
using System.Reactive.Linq;

namespace Metcom.CardPay3.WpfApplication.ViewModels.Employes.AddressCRUD
{
    public class AddressListViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment { get { return "AddressList"; } }
        public IScreen HostScreen { get; protected set; }

        //private readonly IRepository<AddressModel> _repositoryAddress;
        //private readonly IAddressListViewModelService _service;

        //public AddressListViewModel(IRepository<AddressModel> repositoryAddress,
        //    IAddressListViewModelService service,
        //    IScreen screen = null)
        //{
        //    _repositoryAddress = repositoryAddress;
        //    _service = service;

        //    HostScreen = screen;

        //    Task.Run(() => Initialize());

        //    //Init collection
        //    ReadOnlyObservableCollection<Address> bindingData;

        //    Cache.Connect()
        //        .Sort(SortExpressionComparer<Address>.Ascending(t => t.FullName))
        //        .ObserveOn(RxApp.MainThreadScheduler)
        //        .Bind(out bindingData)
        //        .Subscribe();

        //    Addresses = bindingData;
        //}

        //private async Task Initialize()
        //{
        //    Cache = await _service.GetAddressByEmployee(SelectedEmployee);

        //}

        public ReadOnlyObservableCollection<Address> Addresses { get; }
        private SourceCache<Address, int> Cache;

        public Employee SelectedEmployee { get; set; }
    }
}
