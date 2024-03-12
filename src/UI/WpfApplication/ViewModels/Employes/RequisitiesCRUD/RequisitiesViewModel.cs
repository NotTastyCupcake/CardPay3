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
using Microsoft.Win32;
using Metcom.CardPay3.WpfApplication.Services;

namespace Metcom.CardPay3.WpfApplication.ViewModels.Employes.RequisitiesCRUD
{
    public class RequisitiesViewModel : ReactiveValidationObject
    {
        protected readonly ILogger<RequisitiesViewModel> _logger;
        protected readonly IRequisitiesViewModelService _service;
        protected readonly IEmployeeBuilder _builder;

        protected readonly IObservable<bool> IsValid;

        public RequisitiesViewModel(
            ILogger<RequisitiesViewModel> logger,
            IRequisitiesViewModelService service,
            IEmployeeBuilder builder)
        {
            IsValid = ValidatableViewModelExtensions.IsValid(this);

            _service = service;
            _builder = builder;
            _logger = logger;

            Validation();

            //this.WhenAnyValue(vm => vm.SelectedCardType).WhereNotNull().Subscribe(vm => Requisites.IdCardType = vm != null ? vm.Id : 0);
            //this.WhenAnyValue(vm => vm.SelectedBankCurrency).WhereNotNull().Subscribe(vm => Requisites.IdCurrency = vm != null ? vm.Id : 0);
            //this.WhenAnyValue(vm => vm.SelectedDivisions).WhereNotNull().Subscribe(vm => Requisites.IdDivision = vm != null ? vm.Id : 0);
            //this.WhenAnyValue(vm => vm.SelectedINN).WhereNotNull().Subscribe(vm => Requisites.INN = vm.HasValue ? vm.Value : 0);
            //this.WhenAnyValue(vm => vm.AccountNumber).WhereNotNull().Subscribe(vm => Requisites.AccountNumber = vm);

            // Включить видимость поля счет если статус реквизита "Добавлен"
            this.WhenAnyValue(vm => vm.SelectedStatus).WhereNotNull().Subscribe(vm =>
            {
                VisibleAccountNumber = vm.Name == StatusList.Added.Name;
            });
        }

        public async Task InitializeAsync()
        {
            CardTypes = await _service.GetTypes();
            Currencys = await _service.GetCurrencies();
            Divisions = await _service.GetDivisions();
            Statuses = await _service.GetStatuses();
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

        public ReadOnlyCollection<BankCardType> CardTypes { get; private set; }
        [Reactive]
        public BankCardType SelectedCardType { get; set; }

        public ReadOnlyCollection<BankCurrency> Currencys { get; private set; }
        [Reactive]
        public BankCurrency SelectedBankCurrency { get; set; }

        public ReadOnlyCollection<BankDivision> Divisions { get; private set; }
        [Reactive]
        public BankDivision SelectedDivisions { get; set; }

        [Reactive]
        public int? SelectedINN { get; set; }

        public ReadOnlyCollection<Status> Statuses { get; private set; }
        [Reactive]
        public Status SelectedStatus { get; set; }

        [Reactive]
        public string InsuranceNumber { get; set; }
        [Reactive]
        public string LatinFirstName { get; set; }
        [Reactive]
        public string LatinLastName { get; set; }

        [Reactive]
        public RequisitesItem Requisites { get; set; }

    }
}
