using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces.Builder;
using Metcom.CardPay3.WpfApplication.Interfaces;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Extensions;
using ReactiveUI.Validation.Helpers;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.ViewModels.Employes
{
    public class CreateDocumentViewModel : ReactiveValidationObject, IRoutableViewModel
    {
        public string UrlPathSegment { get { return "CreateDocument"; } }
        public IScreen HostScreen { get; protected set; }

        private readonly IDocumentViewModelService _service;
        private readonly IEmployeeBuilderSendObj _builder;

        public CreateDocumentViewModel(
            IDocumentViewModelService service,
            IEmployeeBuilderSendObj builder,
            IScreen screen = null)
        {
            _service = service;
            _builder = builder;

            HostScreen = screen;

            Validation();

            CreateCommand = ReactiveCommand.Create(delegate ()
            {
                var doc = new DocumentItem(SelectedType.Id,
                                           Series,
                                           Number,
                                           DataIssued.Value,
                                           IssuedBy,
                                           SubdivisionCode);

                var vm = Locator.Current.GetService<CreateEmployeeViewModel>();
                vm.Document = doc;

                HostScreen.Router.NavigateBack.Execute();

            }, this.IsValid());

            Task.Run(async () => await Initialize());
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
        }

        private async Task Initialize()
        {
            Types = await _service.GetDocumentTypes();
        }

        public ReactiveCommand<Unit, Unit> CreateCommand { get; }

        #region Model
        [Reactive]
        public DocumentType SelectedType { get; set; }
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

    }
}
