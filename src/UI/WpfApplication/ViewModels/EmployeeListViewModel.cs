using Castle.Core.Logging;
using DynamicData;
using DynamicData.Binding;
using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.WpfApplication.Interfaces;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;

namespace Metcom.CardPay3.WpfApplication.ViewModels
{
    public class EmployeeListViewModel : ReactiveObject, IRoutableViewModel, IDisposable
    {
        public string UrlPathSegment { get { return "EmployeeList"; } }
        public IScreen HostScreen { get; protected set; }

        private readonly IRepository<Employe> _itemRepository;
        private readonly ILogger<EmployeeListViewModel> _logger;
        private readonly IEmployeViewModelService _employeViewModelService;
        private readonly IDisposable _cleanUp;

        public EmployeeListViewModel(
            IEmployeViewModelService viewModelService,
            ILogger<EmployeeListViewModel> logger,
            IRepository<Employe> itemRepository,
            IScreen screen = null)
        {
            _employeViewModelService = viewModelService;
            _logger = logger;

            _itemRepository = itemRepository;

            HostScreen = screen;

            ReadOnlyObservableCollection<Employe> bindingData;



            var items = Task.Run(() => _employeViewModelService.GetEmployes(1)).Result;

            _cleanUp = items.Connect()
                .Sort(SortExpressionComparer<Employe>.Ascending(t => t.FullName))
                .Bind(out bindingData)
                .Subscribe();

            Employes = bindingData;

        }

        #region Properties
        public ReadOnlyObservableCollection<Employe> Employes { get; }

        public void Dispose()
        {
            _cleanUp.Dispose();
        }
        #endregion
    }
}