using DynamicData;
using DynamicData.Binding;
using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.ApplicationCore.Interfaces.OneC;
using Metcom.CardPay3.WpfApplication.Interfaces;
using Metcom.CardPay3.WpfApplication.Models;
using Metcom.CardPay3.WpfApplication.Views;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using Splat.Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;


namespace Metcom.CardPay3.WpfApplication.ViewModels.Employes
{
    public class EmployeeListViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment { get { return "EmployeeList"; } }
        public IScreen HostScreen { get; protected set; }

        private readonly IRepository<Employee> _itemRepository;
        private readonly ILogger<EmployeeListViewModel> _logger;
        private readonly IEmployeeViewModelService _employeViewModelService;
        private readonly IEmployeeCollectionService _employeCollectionService;
        private readonly IOneCService _cService;

        public EmployeeListViewModel(
            IEmployeeViewModelService viewModelService,
            IEmployeeCollectionService employeCollectionService,
            IRepository<Employee> itemRepository,
            IOneCService cService,
            ILogger<EmployeeListViewModel> logger,
            IScreen screen = null)
        {
            _employeViewModelService = viewModelService;
            _employeCollectionService = employeCollectionService;
            _itemRepository = itemRepository;
            _cService = cService;
            _logger = logger;

            HostScreen = screen;

            //Init collection
            ReadOnlyObservableCollection<SelectableItemWrapper<Employee>> bindingData;

            _employeCollectionService.All.Connect()
                .Sort(SortExpressionComparer<SelectableItemWrapper<Employee>>.Ascending(t => t.Item.FullName))
                .Filter(e => FilterStatus == null || e.Item.Requisite.Status == FilterStatus)
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(out bindingData)
                .Subscribe();

            Employes = bindingData;


            #region commands
            UpdateEmployeesCollectionCommand = ReactiveCommand.CreateFromTask(async delegate ()
            {
                await _employeCollectionService.LoadOrUpdateEmployeesCollection();
            });

            RoutingAddEmployeeCommand = ReactiveCommand.CreateFromTask(async delegate() 
            {
                var vm = Locator.Current.GetService<CreateEmployeeViewModel>();
                await vm.InitializeAsync();
                await HostScreen.Router.Navigate.Execute(vm);
            });

            RoutingDeleteEmployeeCommand = ReactiveCommand.CreateFromTask<Employee>(async employee =>
            {
                await _itemRepository.DeleteAsync(employee);
                await _itemRepository.SaveChangesAsync();
                System.Windows.Forms.MessageBox.Show("Выбранный сотрудник, удален!");
                await _employeCollectionService.LoadOrUpdateEmployeesCollection();
            });

            RoutingEditEmployeeCommand = ReactiveCommand.CreateFromTask<Employee>(async employee =>
            {
                var vm = Locator.Current.GetService<EditEmployeeViewModel>();
                await vm.InitializeAsync();
                //TODO: Придумать как упростить передачу в View существующих данных
                vm.Employee = employee;
                vm.FirstName = employee.FirstName;
                vm.LastName = employee.LastName;
                vm.GenderSelected = employee.Gender;
                vm.BirthdayDateSelected = employee.BirthdayDate;
                vm.DocumentViewModel = employee.Document;
                vm.RequisiteViewModel = employee.Requisite;
                vm.ResidentSelected = employee.Resident;
                vm.TypeSelected = employee.Type;

                await HostScreen.Router.Navigate.Execute(vm);
            });

            #region collection commands
            OpenAccountsCommand = ReactiveCommand.CreateFromTask(async delegate ()
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "Расширяемый язык разметки(*.xml)| *.xml";
                if (saveFile.ShowDialog() == true)
                {
                    await _cService.OpenAccounts(Locator.Current.GetService<ShallViewModel>().SelectedOrganization,
                                                Employes.Where(c => c.IsSelected == true)
                                                        .Select(c => c.Item)
                                                        .ToList(),
                                                saveFile.FileName);
                }
            });
            OpenAccountsCommand = ReactiveCommand.CreateFromTask(async delegate ()
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "Расширяемый язык разметки(*.xml)| *.xml";
                if (saveFile.ShowDialog() == true)
                {
                    await _cService.OpenAccounts(Locator.Current.GetService<ShallViewModel>().SelectedOrganization,
                                                Employes.Where(c => c.IsSelected == true)
                                                        .Select(c => c.Item)
                                                        .ToList(),
                                                saveFile.FileName);
                }
            });
            #endregion

            #endregion

            this.WhenAnyValue(vm => vm.FilterStatus).WhereNotNull().Subscribe(async vm => await _employeCollectionService.LoadOrUpdateEmployeesCollection());
        }

        public async Task InitializeAsync()
        {
            FilterStatuses = await _employeCollectionService.GetStatusesCollection();
            FilterStatus = FilterStatuses.FirstOrDefault();
        }

        #region commands
        
        public ReactiveCommand<Unit, Unit> RoutingAddEmployeeCommand { get; }
        public ReactiveCommand<Employee, Unit> RoutingEditEmployeeCommand { get; }
        public ReactiveCommand<Employee, Unit> RoutingDeleteEmployeeCommand { get; }
        public ReactiveCommand<Unit, Unit> UpdateEmployeesCollectionCommand { get; }

        public ReactiveCommand<Unit, Unit> OpenAccountsCommand { get; }
        #endregion

        #region Properties
        public ReadOnlyObservableCollection<SelectableItemWrapper<Employee>> Employes { get; }

        [Reactive]
        public ReadOnlyCollection<Status> FilterStatuses { get; set; }
        [Reactive]
        public Status FilterStatus { get; set; }
        #endregion
    }
}