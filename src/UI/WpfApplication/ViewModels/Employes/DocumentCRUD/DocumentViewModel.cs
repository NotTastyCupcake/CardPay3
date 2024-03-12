using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces.Builder;
using Metcom.CardPay3.WpfApplication.Interfaces;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Extensions;
using ReactiveUI.Validation.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.ViewModels.Employes.DocumentCRUD
{
    public class DocumentViewModel : ReactiveValidationObject
    {
        protected readonly IDocumentViewModelService _service;
        protected readonly IEmployeeBuilder _builder;

        protected readonly IObservable<bool> IsValid;

        public DocumentViewModel(
            IDocumentViewModelService service,
            IEmployeeBuilder builder)
        {
            IsValid = this.IsValid();

            _service = service;
            _builder = builder;
            Validation();

            //this.WhenAnyValue(vm => vm.SelectedType).WhereNotNull().Subscribe(vm => Document.IdType = vm?.Id ?? 0);
            //this.WhenAnyValue(vm => vm.Series).WhereNotNull().Subscribe(vm => Document.Series = vm);
            //this.WhenAnyValue(vm => vm.SelectedDataIssued).WhereNotNull().Subscribe(vm => Document.DataIssued = vm.Value);

        }
        public async Task InitializeAsync()
        {
            Types = await _service.GetDocumentTypes();
        }

        private void Validation()
        {
            this.ValidationRule(
                viewModel => viewModel.SelectedType,
                item => item != null,
                "Тип документа должнен быть заполнен обязательно");

            this.ValidationRule(
                viewModel => viewModel.SelectedDataIssued,
                item => item.HasValue && item.Value < DateTime.Now,
                "Дата должнена быть заполнена обязательно");

            this.ValidationRule(
                viewModel => viewModel.Series,
                item => !string.IsNullOrWhiteSpace(item),
                "Серия должна быть заполнена обязательно");
        }



        #region Model

        [Reactive]
        public DocumentType SelectedType { get; set; }

        [Reactive]
        public string Series { get; set; }


        [Reactive]
        public DateTime? SelectedDataIssued { get; set; }
        #endregion

        public ReadOnlyObservableCollection<DocumentType> Types { get; private set; }

        /// <summary>
        /// Вид документа, удостоверяющего личность.
        /// </summary>
        public int IdType { get; set; }

        /// <summary>
        /// Номер
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// Дата выдачи
        /// </summary>
        public DateTime DataIssued { get; set; }
        /// <summary>
        /// Кем выдан
        /// </summary>
        public string IssuedBy { get; set; }
        /// <summary>
        /// Код подразделения
        /// </summary>
        public string SubdivisionCode { get; set; }


        [Reactive]
        public DocumentItem Document { get; set; }
    }
}
