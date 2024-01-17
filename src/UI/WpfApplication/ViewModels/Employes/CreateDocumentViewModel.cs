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
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.ViewModels.Employes
{
    public class CreateDocumentViewModel : DocumentViewModel, IRoutableViewModel
    {
        public string UrlPathSegment { get { return "CreateDocument"; } }
        public IScreen HostScreen { get; protected set; }

        public CreateDocumentViewModel(
            IDocumentViewModelService service,
            IEmployeeBuilder builder,
            IScreen screen = null) : base(service, builder)
        {
            HostScreen = screen;

            CreateCommand = ReactiveCommand.CreateFromTask( async () =>
            {

                var doc = new DocumentItem(this);
                Document = doc;
                await _builder.SetDocument(Document);
                HostScreen.Router.NavigateBack.Execute();

            }, this.IsValid());
        }

        public ReactiveCommand<Unit, Unit> CreateCommand { get; }



    }
}
