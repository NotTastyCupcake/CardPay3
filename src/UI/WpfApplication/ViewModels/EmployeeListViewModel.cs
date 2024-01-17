using DynamicData;
using DynamicData.Binding;
using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.WpfApplication.Interfaces;
using Metcom.CardPay3.WpfApplication.ViewModels.Employes;
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


namespace Metcom.CardPay3.WpfApplication.ViewModels
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

            SelectedOrganization = Locator.Current.GetService<HomeViewModel>().SelectedOrganization;

            //Init collection
            ReadOnlyObservableCollection<Employee> bindingData;

            employeCollectionService.All.Connect()
                .Sort(SortExpressionComparer<Employee>.Ascending(t => t.FullName))
                .Filter(e => e.Organization == SelectedOrganization)
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(out bindingData)
                .Subscribe();

            Employes = bindingData;


            // commands
            RoutingAddEmployeeCommand = ReactiveCommand.Create(CreateEmploye());
            RoutingDeleteEmployeeCommand = ReactiveCommand.Create(DeleteEmploye());
            //TODO: Добавить редактирование сотрудника
            //RoutingEditEmployeeCommand = ReactiveCommand.Create(EditEmploye());
            ExportEmployeeCommand = ReactiveCommand.Create(ExportEmployee());
        }


        #region commands
        public ReactiveCommand<Unit, Unit> RoutingEditEmployeeCommand { get; }
        public ReactiveCommand<Unit, Unit> RoutingAddEmployeeCommand { get; }
        public ReactiveCommand<Unit, Unit> RoutingDeleteEmployeeCommand { get; }

        public ReactiveCommand<Unit, Unit> ExportEmployeeCommand { get; }

        private Action CreateEmploye()
        {
            return delegate () 
            {
                var vm = Locator.Current.GetService<CreateEmployeeViewModel>();

                HostScreen.Router.Navigate.Execute(vm);

            };
        }

        private Action DeleteEmploye()
        {
            return async delegate ()
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

            };
        }


        private Action ExportEmployee()
        {
            return async delegate ()
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "Расширяемый язык разметки(*.json)| *.json";
                //"|Расширяемый язык разметки(*.xml)| *.xml"; //Не понятно как преобразовать List<Employe> в XML без атребутов
                if (saveFile.ShowDialog() == true)
                {
                    await _exportService.ExportDataAsync(saveFile.SafeFileName.Split('.').LastOrDefault(), saveFile.FileName);
                }
            };
        }
        #endregion

        #region Properties
        public ReadOnlyObservableCollection<Employee> Employes { get; }

        [Reactive]
        public Employee SelectedEmploye { get; set; }

        [Reactive]
        public Organization SelectedOrganization { get; set; }
        #endregion
    }
}