using DynamicData;
using DynamicData.Binding;
using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.WpfApplication.Interfaces;
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

        public EmployeeListViewModel(
            IEmployeeViewModelService viewModelService,
            IEmployeeCollectionService employeCollectionService,
            ILogger<EmployeeListViewModel> logger,
            IDataExportService exportService,
            IRepository<Employee> itemRepository,
            IScreen screen = null)
        {
            _employeViewModelService = viewModelService;
            _logger = logger;
            _exportService = exportService;

            _itemRepository = itemRepository;

            HostScreen = screen;

            //Init collection
            employeCollectionService.LoadOrUpdateEmployeesCollection();

            ReadOnlyObservableCollection<Employee> bindingData;

            employeCollectionService.All.Connect()
                .Sort(SortExpressionComparer<Employee>.Ascending(t => t.FullName))
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(out bindingData)
                .Subscribe();

            Employes = bindingData;

            #region commands
            UpdateEmployeesCollectionCommand = ReactiveCommand.CreateFromTask(async delegate ()
            {
                await employeCollectionService.LoadOrUpdateEmployeesCollection();
            });

            RoutingAddEmployeeCommand = ReactiveCommand.CreateFromTask(async delegate() 
            {
                var vm = Locator.Current.GetService<CreateEmployeeViewModel>();
                await vm.InitializeAsync();
                await HostScreen.Router.Navigate.Execute(vm);
            });

            RoutingDeleteEmployeeCommand = ReactiveCommand.CreateFromTask(async delegate ()
            {
                if (SelectedEmploye == null)
                {

                }
                else
                {
                    await _itemRepository.DeleteAsync(SelectedEmploye);
                    await _itemRepository.SaveChangesAsync();
                    System.Windows.Forms.MessageBox.Show("Выбранный сотрудник, удален!");
                }
            });

            RoutingEditEmployeeCommand = ReactiveCommand.CreateFromTask(async delegate ()
            {
                if (SelectedEmploye == null)
                {


                }
                else
                {
                    var vm = Locator.Current.GetService<EditEmployeeViewModel>();
                    await vm.InitializeAsync();
                    vm.GetEmployeeToEdit(SelectedEmploye);
                    await HostScreen.Router.Navigate.Execute(vm);
                }
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
        }

        #region commands
        public ReactiveCommand<Unit, Unit> RoutingEditEmployeeCommand { get; }
        public ReactiveCommand<Unit, Unit> RoutingAddEmployeeCommand { get; }
        public ReactiveCommand<Unit, Unit> RoutingDeleteEmployeeCommand { get; }
        public ReactiveCommand<Unit, Unit> UpdateEmployeesCollectionCommand { get; }

        public ReactiveCommand<Unit, Unit> ExportEmployeeCommand { get; }
        #endregion

        #region Properties
        public ReadOnlyObservableCollection<Employee> Employes { get; }

        [Reactive]
        public Employee SelectedEmploye { get; set; }
        #endregion
    }
}