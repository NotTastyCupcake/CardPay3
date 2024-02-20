using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces.Builder;
using Metcom.CardPay3.WpfApplication.Interfaces;
using Microsoft.Extensions.Logging;
using ReactiveUI.Validation.Extensions;
using ReactiveUI;
using ReactiveUI.Validation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using Metcom.CardPay3.Infrastructure.Data;

namespace Metcom.CardPay3.WpfApplication.ViewModels.Employes.RequisitiesCRUD
{
    public class RequisitiesViewModel : ReactiveValidationObject, IRequisitesItem
    {
        protected readonly ILogger<RequisitiesViewModel> _logger;
        protected readonly IRepository<RequisitesItem> _repository;
        protected readonly IRepository<BankCardType> _typeRepository;
        protected readonly IRepository<BankCurrency> _currencyRepository;
        protected readonly IRepository<BankDivision> _divisionRepository;
        protected readonly IRepository<Status> _statusRepository;
        protected readonly IEmployeeBuilder _builder;

        protected readonly IObservable<bool> IsValid;

        public RequisitiesViewModel(
            ILogger<RequisitiesViewModel> logger,
            IRepository<RequisitesItem> repository,
            IRepository<BankCardType> typeRepository,
            IRepository<BankCurrency> currencyRepository,
            IRepository<BankDivision> divisionRepository,
            IRepository<Status> statusRepository,
            IEmployeeBuilder builder)
        {
            IsValid = ValidatableViewModelExtensions.IsValid(this);

            _repository = repository;
            _typeRepository = typeRepository;
            _currencyRepository = currencyRepository;
            _divisionRepository = divisionRepository;
            _statusRepository = statusRepository;
            _builder = builder;
            _logger = logger;

            Validation();

            this.WhenAnyValue(vm => vm.SelectedCardType).Subscribe(vm => IdCardType = vm != null ? vm.Id : 0);
            this.WhenAnyValue(vm => vm.SelectedBankCurrency).Subscribe(vm => IdCurrency = vm != null ? vm.Id : 0);
            this.WhenAnyValue(vm => vm.SelectedDivisions).Subscribe(vm => IdDivision = vm != null ? vm.Id : 0);
            this.WhenAnyValue(vm => vm.SelectedINN).Subscribe(vm => INN = vm.HasValue ? vm.Value : 0);
            // Включить видимость поля счет если статус реквизита "Добавлен"
            this.WhenAnyValue(vm => vm.SelectedStatus).WhereNotNull().Subscribe(vm => 
            { 
                VisibleAccountNumber = vm.Name.Contains("Добавлен");
                IdStatus = SelectedStatus.Id;
            });
        }

        public async Task InitializeAsync()
        {
            CardTypes = new ReadOnlyCollection<BankCardType>(await _typeRepository.ListAsync());
            Currencys = new ReadOnlyCollection<BankCurrency>(await _currencyRepository.ListAsync());
            Divisions = new ReadOnlyCollection<BankDivision>(await _divisionRepository.ListAsync());
            Statuses = new ReadOnlyCollection<Status>(await _statusRepository.ListAsync());
        }

        private void Validation()
        {

            this.ValidationRule(
                viewModel => viewModel.SelectedCardType,
                item => item != null,
                "Тип карты должен быть выбран обязательно");

            this.ValidationRule(
                viewModel => viewModel.SelectedBankCurrency,
                item => item != null,
                "Валюта должна быть выбрана обязательно");

            this.ValidationRule(
                viewModel => viewModel.SelectedDivisions,
                item => item != null,
                "Отделение банка должно быть выбрано обязательно");

            this.ValidationRule(
                viewModel => viewModel.SelectedStatus,
                item => item != null,
                "Статус счета должен быть выбран обязательно.");

            this.ValidationRule(
                viewModel => viewModel.VisibleAccountNumber,
                item => item == false || AccountNumber != null,
                "Cчет должен быть заполнен обязательно.");
        }

        [Reactive]
        public string AccountNumber { get; set; }
        [Reactive]
        public bool VisibleAccountNumber { get; set; }

        [Reactive]
        public ReadOnlyCollection<BankCardType> CardTypes { get; set; }
        [Reactive]
        public BankCardType SelectedCardType { get; set; }
        public int IdCardType { get; set; }

        [Reactive]
        public ReadOnlyCollection<BankCurrency> Currencys { get; set; }
        [Reactive]
        public BankCurrency SelectedBankCurrency { get; set; }
        public int IdCurrency { get; set; }

        [Reactive]
        public ReadOnlyCollection<BankDivision> Divisions { get; set; }
        [Reactive]
        public BankDivision SelectedDivisions { get; set; }
        public int IdDivision { get; set; }

        [Reactive]
        public int INN { get; set; }
        [Reactive]
        public int? SelectedINN { get; set; }
        [Reactive]
        public string InsuranceNumber { get; set; }
        [Reactive]
        public string LatinFirstName { get; set; }
        [Reactive]
        public string LatinLastName { get; set; }

        [Reactive]
        public ReadOnlyCollection<Status> Statuses { get; set; }
        [Reactive]
        public Status SelectedStatus { get; set; }
        [Reactive]
        public int IdStatus { get; set; }
    }
}
