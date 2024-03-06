using DynamicData;
using DynamicData.Binding;
using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.WpfApplication.Interfaces;
using Metcom.CardPay3.WpfApplication.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using Splat.Microsoft.Extensions.DependencyInjection;
using System;
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
        private readonly IDataExportService _exportService;
        private readonly IEmployeeViewModelService _employeViewModelService;
        private readonly IEmployeeCollectionService _employeCollectionService;

        public EmployeeListViewModel(
            IEmployeeViewModelService viewModelService,
            IEmployeeCollectionService employeCollectionService,
            ILogger<EmployeeListViewModel> logger,
            IDataExportService exportService,
            IRepository<Employee> itemRepository,
            IScreen screen = null)
        {
            _employeViewModelService = viewModelService;
            _employeCollectionService = employeCollectionService;
            _logger = logger;
            _exportService = exportService;

            _itemRepository = itemRepository;

            HostScreen = screen;

            //Init collection
            ReadOnlyObservableCollection<Employee> bindingData;

            _employeCollectionService.All.Connect()
                .Sort(SortExpressionComparer<Employee>.Ascending(t => t.FullName))
                .Filter(e => FilterStatus == null || e.Requisite.Status == FilterStatus)
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
                vm.GetEmployeeToEdit(employee);
                await HostScreen.Router.Navigate.Execute(vm);
            });

            ExportEmployeeCommand = ReactiveCommand.CreateFromTask(async delegate ()
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "Расширяемый язык разметки(*.json)| *.json";
                //"|Расширяемый язык разметки(*.xml)| *.xml"; //Не понятно как преобразовать List<Employe> в XML без атребутов
                if (saveFile.ShowDialog() == true)
                {
                    await _exportService.ExportDataAsync(
                        saveFile.SafeFileName.Split('.').LastOrDefault(),
                        saveFile.FileName,
                        Locator.Current.GetService<ShallViewModel>().SelectedOrganization.Id);
                }
            });
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

        public ReactiveCommand<Unit, Unit> ExportEmployeeCommand { get; }
        #endregion

        #region Properties
        public ReadOnlyObservableCollection<Employee> Employes { get; }
        [Reactive]
        public Employee SelectedEmploye { get; set; }

        [Reactive]
        public ReadOnlyCollection<Status> FilterStatuses { get; set; }
        [Reactive]
        public Status FilterStatus { get; set; }
        #endregion
    }
}