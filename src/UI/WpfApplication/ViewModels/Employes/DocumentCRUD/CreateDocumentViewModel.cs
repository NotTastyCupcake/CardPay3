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
using System.Reactive.Linq;

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
                Document = new DocumentItem()
                {
                    DataIssued = base.DataIssued,
                    IssuedBy = base.IssuedBy,
                    Number = base.Number,
                    Series = base.Series,
                    SubdivisionCode = base.SubdivisionCode,
                    Type = base.SelectedType,
                    IdType = base.IdType
                };

                await HostScreen.Router.NavigateBack.Execute();

            }, this.IsValid());
        }

        public ReactiveCommand<Unit, Unit> CreateCommand { get; }


    }
}
