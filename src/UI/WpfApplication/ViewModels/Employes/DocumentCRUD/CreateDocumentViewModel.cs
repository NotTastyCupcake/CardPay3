using Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces.Builder;
using Metcom.CardPay3.WpfApplication.Interfaces;
using ReactiveUI.Validation.Extensions;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;

namespace Metcom.CardPay3.WpfApplication.ViewModels.Employes.DocumentCRUD
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

            CreateCommand = ReactiveCommand.CreateFromTask(async () =>
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
