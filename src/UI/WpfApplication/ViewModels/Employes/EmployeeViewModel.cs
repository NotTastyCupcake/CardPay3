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

        public EmployeeViewModel(IRepository<Gender> genderRepo,
            IRepository<EmployeeType> employeeType,
            ILogger<CreateEmployeeViewModel> logger,
            IEmployeeViewModelService viewModelService,
            IEmployeeBuilder builder)
        {
            IsValid = ValidatableViewModelExtensions.IsValid(this);

            _genderRepo = genderRepo;
            _employeeType = employeeType;

            _logger = logger;
            _employeViewModelService = viewModelService;
            _builder = builder;


            Validation();

            Task.Run(() => Initialize());

            this.WhenAnyValue(vm => vm.BirthdayDateSelected).Subscribe(vm => BirthdayDate = vm.HasValue ? vm.Value : DateTime.MinValue);
            this.WhenAnyValue(vm => vm.ResidentSelected).Subscribe(vm => Resident = vm.HasValue ? vm.Value : false);
        }

        private async Task Initialize()
        {
            Genders = new ObservableCollection<Gender>(await _genderRepo.ListAsync());
            EmployeeTypes = new ObservableCollection<EmployeeType>(await _employeeType.ListAsync());
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
        }

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
        public ICollection<RequisitesItem> Requisites { get; set; }

        [Reactive]
        public bool Resident { get; set; }
        [Reactive]
        public bool? ResidentSelected { get; set; }

        [Reactive]
        public EmployeeType Type { get; set; }
        #endregion

        [Reactive]
        public ObservableCollection<Gender> Genders { get; set; }
        [Reactive]
        public ObservableCollection<EmployeeType> EmployeeTypes { get; set; }

    }
}
