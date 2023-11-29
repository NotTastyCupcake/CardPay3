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

        private readonly IRepository<Employe> _itemRepository;
        private readonly ILogger<EmployeeListViewModel> _logger;
        private readonly IDataExportService _exportService;
        private readonly IEmployeViewModelService _employeViewModelService;

        public EmployeeListViewModel(
            IEmployeViewModelService viewModelService,
            IEmployeCollectionService employeCollectionService,
            ILogger<EmployeeListViewModel> logger,
            IDataExportService exportService,
            IRepository<Employe> itemRepository,
            IScreen screen = null)
        {
            _employeViewModelService = viewModelService;
            _logger = logger;
            _exportService = exportService;

            _itemRepository = itemRepository;

            HostScreen = screen;

            SelectedOrganization = Locator.Current.GetService<MenuViewModel>().SelectedOrganization;

            //Init collection
            ReadOnlyObservableCollection<Employe> bindingData;

            employeCollectionService.All.Connect()
                .Sort(SortExpressionComparer<Employe>.Ascending(t => t.FullName))
                .Filter(e => e.Organization == SelectedOrganization)
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(out bindingData)
                .Subscribe();

            Employes = bindingData;


            // commands
            RoutingAddEmployeeCommand = ReactiveCommand.Create(CreateEmploye());
            RoutingDeleteEmployeeCommand = ReactiveCommand.Create(DeleteEmploye());
            RoutingEditEmployeeCommand = ReactiveCommand.Create(EditEmploye());
            ExportEmployeeCommand = ReactiveCommand.Create(ExportEmploye());
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
                var vm = Locator.Current.GetService<EmployeViewModel>();
                vm.Employe = new Employe();
                vm.SelectedOperation = Constants.Operations.Create;
                HostScreen.Router.Navigate.Execute(vm);

            };
        }

        private Action EditEmploye()
        {
            return delegate ()
            {
                if (SelectedEmploye == null)
                {

                }
                else
                {
                    var vm = Locator.Current.GetService<EmployeViewModel>();
                    //TODO: Убрать передачу, вытягивать через Locator.Current.GetService<MenuViewModel>().SelectedOrganization
                    vm.Employe = SelectedEmploye;
                    vm.SelectedOperation = Constants.Operations.Edit;
                    HostScreen.Router.Navigate.Execute(vm);
                }

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


        private Action ExportEmploye()
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
        public ReadOnlyObservableCollection<Employe> Employes { get; }

        [Reactive]
        public Employe SelectedEmploye { get; set; }

        [Reactive]
        public Organization SelectedOrganization { get; set; }
        #endregion
    }
}