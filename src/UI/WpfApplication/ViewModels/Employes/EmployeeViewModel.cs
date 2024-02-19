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

namespace Metcom.CardPay3.WpfApplication.ViewModels.Employes
{
    public class EmployeeViewModel : ReactiveValidationObject, IEmployee
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
                vm.WhenAnyValue(vm => vm.Document).Subscribe(d => Document = d);
            });
            CreateRequisitCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                var vm = Locator.Current.GetService<CreateRequisitiesViewModel>();
                await vm.InitializeAsync();
                await HostScreen.Router.Navigate.Execute(vm);
                vm.WhenAnyValue(vm => vm.Item).Subscribe(r => Requisite = r);
            });
            #endregion


            this.WhenAnyValue(vm => vm.BirthdayDateSelected).Subscribe(vm => BirthdayDate = vm.HasValue ? vm.Value : DateTime.MinValue);
            this.WhenAnyValue(vm => vm.ResidentSelected).Subscribe(vm => Resident = vm.HasValue ? vm.Value : false);
            this.WhenAnyValue(vm => vm.RequisitFullName).Subscribe();
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
                viewModel => viewModel.Gender,
                item => item != null,
                "Гендер должен быть заполнен обязательно");

            this.ValidationRule(
                viewModel => viewModel.Document,
                item => item != null,
                "Документ должен быть заполнен обязательно");

            this.ValidationRule(
                viewModel => viewModel.ResidentSelected,
                item => item != null,
                "Резидентность должна быть заполнена обязательно");

            this.ValidationRule(
                viewModel => viewModel.Requisite,
                item => item != null,
                "Реквизит должен быть заполнен обязательно");
        }

        #region commands
        public ReactiveCommand<Unit, Unit> CreateDocumentCommand { get; }
        public ReactiveCommand<Unit, Unit> CreateRequisitCommand { get; }
        #endregion

        #region property
        [Reactive]
        public ICollection<Address> Addresses { get; set; }
        [Reactive]
        public DateTime BirthdayDate { get; set; }
        [Reactive]
        public DateTime? BirthdayDateSelected { get; set; }
        [Reactive]
        public string BonusNumber { get; set; }
        [Reactive]
        public string DepartmentNum { get; set; }
        [Reactive]
        public DocumentItem Document { get; set; }
        [Reactive]
        public string EMail { get; set; }
        [Reactive]
        public string FirstName { get; set; }
        [Reactive]
        public Gender Gender { get; set; }
        [Reactive]
        public int? IdDocument { get; set; }
        [Reactive]
        public int IdGender { get; set; }
        [Reactive]
        public int IdOrganization { get; set; }
        [Reactive]
        public int? IdType { get; set; }
        [Reactive]
        public string JobPhoneNumber { get; set; }
        [Reactive]
        public string LastName { get; set; }
        [Reactive]
        public string MiddleName { get; set; }
        [Reactive]
        public string Nationality { get; set; }
        [Reactive]
        public Organization Organization { get; set; }
        [Reactive]
        public string PhoneNumber { get; set; }
        [Reactive]
        public string Position { get; set; }

        [Reactive]
        public int IdRequisite { get; set; }
        [Reactive]
        public RequisitesItem Requisite { get; set; }

        public string RequisitFullName => $"{Requisite?.Status?.Name ?? "<Нет статуса>"}, {Requisite?.Currency?.NameCurrency ?? "<Нет валюты>"}";

        [Reactive]
        public bool Resident { get; set; }
        [Reactive]
        public bool? ResidentSelected { get; set; }

        [Reactive]
        public EmployeeType Type { get; set; }
        #endregion

        [Reactive]
        public ReadOnlyCollection<Gender> Genders { get; set; }
        [Reactive]
        public ReadOnlyCollection<EmployeeType> EmployeeTypes { get; set; }

    }
}
