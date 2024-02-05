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
    public class DocumentViewModel : ReactiveValidationObject, IDocumentItem
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

            Task.Run(() => Initialize());

            Validation();

            this.WhenAnyValue(vm => vm.SelectedType).Subscribe(_ => IdType = SelectedType?.Id ?? 0);
        }

        private void Validation()
        {
            this.ValidationRule(
                viewModel => viewModel.SelectedType,
                item => item != null,
                "Тип документа должнен быть заполнен обязательно");

            this.ValidationRule(
                viewModel => viewModel.DataIssued,
                item => item.HasValue,
                "Дата должнена быть заполнена обязательно");

            this.ValidationRule(
                viewModel => viewModel.Series,
                item => !string.IsNullOrWhiteSpace(item),
                "Серия должна быть заполнена обязательно");
        }

        private async Task Initialize()
        {
            Types = await _service.GetDocumentTypes();
        }

        #region Model
        [Reactive]
        public DocumentType SelectedType { get; set; }

        [Reactive]
        public int IdType { get; set; }

        [Reactive]
        public string Series { get; set; }
        [Reactive]
        public string Number { get; set; }
        [Reactive]
        public DateTime? DataIssued { get; set; }
        [Reactive]
        public string IssuedBy { get; set; }
        [Reactive]
        public string SubdivisionCode { get; set; }
        #endregion

        [Reactive]
        public ReadOnlyObservableCollection<DocumentType> Types { get; set; }

        [Reactive]
        public DocumentItem Document { get; set; }
    }
}
