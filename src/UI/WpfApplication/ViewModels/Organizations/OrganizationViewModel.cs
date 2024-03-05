using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Extensions;
using ReactiveUI.Validation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.ViewModels.Organizations
{
    public class OrganizationViewModel : ReactiveValidationObject, IOrganization
    {
        protected readonly IObservable<bool> IsValid;

        protected readonly ILogger<OrganizationViewModel> _logger;
        protected readonly IRepository<Organization> _repositoryOrganization;

        public OrganizationViewModel(ILogger<OrganizationViewModel> logger,
            IRepository<Organization> repositoryOrganization)
        {
            _logger = logger;
            _repositoryOrganization = repositoryOrganization;

            IsValid = ValidatableViewModelExtensions.IsValid(this);
            Validation();

            this.WhenAnyValue(vm => vm.SelectedCreateDate).WhereNotNull().Subscribe(d => CreateDate = d.Value);
            this.WhenAnyValue(vm => vm.SelectedApplicationDate).WhereNotNull().Subscribe(d => ApplicationDate = d.Value);
        }

        private void Validation()
        {
            this.ValidationRule(
                viewModel => viewModel.SelectedCreateDate,
                item => item.HasValue,
                "Дата формирования должна быть заполнена обязательно");

            this.ValidationRule(
                viewModel => viewModel.ApplicationNumber,
                item => !string.IsNullOrWhiteSpace(item) && !new Regex("[^0-9.-]+").IsMatch(item),
                "Номер договора должнен быть заполнен обязательно");

            this.ValidationRule(
                viewModel => viewModel.Name,
                item => !string.IsNullOrWhiteSpace(item),
                "Название должно быть заполнено обязательно");

            this.ValidationRule(
                viewModel => viewModel.SourceId,
                item => !string.IsNullOrWhiteSpace(item) && !new Regex("[^0-9.-]+").IsMatch(item),
                "Ид первичного документа должно быть заполнено обязательно");
        }

        [Reactive]
        public string Name { get; set; }

        /// <summary>
        /// Дата формирования
        /// </summary>
        [Reactive]
        public DateTime CreateDate { get; set; }
        [Reactive]
        public DateTime? SelectedCreateDate { get; set; }

        [Reactive]
        public string INN { get; set; }
        /// <summary>
        /// Номер договора
        /// </summary>
        [Reactive]
        public string ApplicationNumber { get; set; }
        [Reactive]
        public DateTime ApplicationDate { get; set; }
        [Reactive]
        public DateTime? SelectedApplicationDate { get; set; }

        [Reactive]
        public string Account { get; set; }
        /// <summary>
        /// Рекомендуется заполнять. БИК банка, с которым заключен зарплатный договор
        /// </summary>
        [Reactive]
        public string BankCode { get; set; }
        /// <summary> 
        /// Ид первичного документа
        /// </summary>
        [Reactive]
        public string SourceId { get; set; }

    }
}
