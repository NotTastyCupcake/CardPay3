using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces.Builder;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.WpfApplication.Interfaces;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using ReactiveUI.Validation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI.Validation.Extensions;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using Metcom.CardPay3.Infrastructure.Data;
using System.Windows.Forms;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.CompilerServices;
using System.Reactive;
using Metcom.CardPay3.WpfApplication.ViewModels.Employes.DocumentCRUD;
using Splat;
using System.Reactive.Linq;
using Metcom.CardPay3.WpfApplication.ViewModels.Employes.RequisitiesCRUD;
using Metcom.CardPay3.WpfApplication.ViewModels.Employes.AddressCRUD;
using ReactiveUI.Validation.States;

namespace Metcom.CardPay3.WpfApplication.ViewModels.Employes
{
    public class EmployeeViewModel : ReactiveValidationObject
    {
        protected readonly IRepository<Gender> _genderRepo;
        protected readonly IRepository<EmployeeType> _employeeType;

        protected readonly ILogger<CreateEmployeeViewModel> _logger;
        protected readonly IEmployeeViewModelService _employeViewModelService;
        protected readonly IEmployeeBuilder _builder;

        protected readonly IObservable<bool> IsValid;
        public IScreen HostScreen { get; protected set; }

        public EmployeeViewModel(IRepository<Gender> genderRepo,
            IRepository<EmployeeType> employeeType,
            ILogger<CreateEmployeeViewModel> logger,
            IEmployeeViewModelService viewModelService,
            IEmployeeBuilder builder,
            IScreen sreen = null)
        {
            HostScreen = sreen;

            IsValid = ValidatableViewModelExtensions.IsValid(this);

            _genderRepo = genderRepo;
            _employeeType = employeeType;

            _logger = logger;
            _employeViewModelService = viewModelService;
            _builder = builder;

            Validation();

            #region commands
            CreateDocumentCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                var vm = Locator.Current.GetService<CreateDocumentViewModel>();
                await vm.InitializeAsync();
                await HostScreen.Router.Navigate.Execute(vm);
                vm.WhenAnyValue(vm => vm.Document).WhereNotNull().Subscribe(d => DocumentViewModel = d);
            });
            CreateRequisitCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                var vm = Locator.Current.GetService<CreateRequisitiesViewModel>();
                await vm.InitializeAsync();
                await HostScreen.Router.Navigate.Execute(vm);
                vm.WhenAnyValue(vm => vm.Requisites).WhereNotNull().Subscribe(r => RequisiteViewModel = r);
            });


            var isRealAddress = this
            .WhenAnyValue(x => x.SelectedAddress)
            .Select(obj => obj != null);


            CreateAddressCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                var vm = Locator.Current.GetService<CreateAddressViewModel>();
                await vm.InitializeAsync();
                await HostScreen.Router.Navigate.Execute(vm);
                vm.WhenAnyValue(vm => vm.Address).WhereNotNull().Subscribe(r => 
                { 
                    _builder.AddAddress(r);
                    AddressesCollection.Add(r); 
                });
            });
            EditAddressCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                //var vm = Locator.Current.GetService<CreateAddressViewModel>();
                //await vm.InitializeAsync();
                //await HostScreen.Router.Navigate.Execute(vm);
                //vm.WhenAnyValue(vm => vm.Address).WhereNotNull().Subscribe(r => AddressesCollection.Add(r));
            }, isRealAddress);
            DeleteAddressCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                //var vm = Locator.Current.GetService<CreateAddressViewModel>();
                //await vm.InitializeAsync();
                //await HostScreen.Router.Navigate.Execute(vm);
                //vm.WhenAnyValue(vm => vm.Address).WhereNotNull().Subscribe(r => AddressesCollection.Add(r));
            }, isRealAddress);
            #endregion

            this.WhenAnyValue(vm => vm.FirstName).Subscribe(vm => Employee.FirstName = vm);
            this.WhenAnyValue(vm => vm.LastName).Subscribe(vm => Employee.LastName = vm);
            this.WhenAnyValue(vm => vm.GenderSelected).Subscribe(vm => Employee.Gender = vm);
            this.WhenAnyValue(vm => vm.DocumentViewModel).Subscribe(vm => Employee.Document = vm);
            this.WhenAnyValue(vm => vm.BirthdayDateSelected).Subscribe(vm => Employee.BirthdayDate = vm.HasValue ? vm.Value : DateTime.MinValue);
            this.WhenAnyValue(vm => vm.ResidentSelected).Subscribe(vm => Employee.Resident = vm.HasValue ? vm.Value : false);
            //this.WhenAnyValue(vm => vm.SelectedAddress).Subscribe();
        }

        public async Task InitializeAsync()
        {
            Genders = new ReadOnlyCollection<Gender>(await _genderRepo.ListAsync());
            EmployeeTypes = new ReadOnlyCollection<EmployeeType>(await _employeeType.ListAsync());
        }

        private void Validation()
        {
            this.ValidationRule(
                viewModel => viewModel.FirstName,
                item => !string.IsNullOrEmpty(item),
                "Имя должно быть заполнено обязательно");

            this.ValidationRule(
                viewModel => viewModel.LastName,
                item => !string.IsNullOrEmpty(item),
                "Фамилия должно быть заполнено обязательно");

            this.ValidationRule(
                viewModel => viewModel.BirthdayDateSelected,
                item => item.HasValue && item.Value != DateTime.MinValue && item.Value != DateTime.Today,
                "Дата рождения должна быть заполнена обязательно");

            this.ValidationRule(
                viewModel => viewModel.GenderSelected,
                item => item != null,
                "Гендер должен быть заполнен обязательно");

            this.ValidationRule(
                viewModel => viewModel.DocumentViewModel,
                item => item != null,
                "Документ должен быть заполнен обязательно");

            this.ValidationRule(
                viewModel => viewModel.ResidentSelected,
                item => item != null,
                "Резидентность должна быть заполнена обязательно");

            this.ValidationRule(
                viewModel => viewModel.RequisiteViewModel,
                item => item != null,
                "Реквизит должен быть заполнен обязательно");
        }

        #region commands
        public ReactiveCommand<Unit, Unit> CreateDocumentCommand { get; }
        public ReactiveCommand<Unit, Unit> CreateRequisitCommand { get; }


        public ReactiveCommand<Unit, Unit> CreateAddressCommand { get; }
        public ReactiveCommand<Unit, Unit> EditAddressCommand { get; }
        public ReactiveCommand<Unit, Unit> DeleteAddressCommand { get; }
        #endregion

        #region property
        [Reactive]
        public Employee Employee { get; set; } = new Employee();

        [Reactive]
        public string FirstName { get; set; }

        [Reactive]
        public string LastName { get; set; }

        [Reactive]
        public Gender GenderSelected { get; set; }

        [Reactive]
        public DateTime? BirthdayDateSelected { get; set; }

        [Reactive]
        public DocumentItem DocumentViewModel { get; set; }

        [Reactive]
        public RequisitesItem RequisiteViewModel { get; set; }

        [Reactive]
        public bool? ResidentSelected { get; set; }

        [Reactive]
        public EmployeeType TypeSelected { get; set; }
        #endregion
        
        public ReadOnlyCollection<Gender> Genders { get; private set; }

        public ReadOnlyCollection<EmployeeType> EmployeeTypes { get; private set; }

        public ObservableCollection<Address> AddressesCollection { get; set; } = new ObservableCollection<Address>();

        [Reactive]
        public Address SelectedAddress { get; set; }
    }
}
