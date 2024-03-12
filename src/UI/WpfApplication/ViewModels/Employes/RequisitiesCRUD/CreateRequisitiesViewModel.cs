using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces.Builder;
using Metcom.CardPay3.WpfApplication.Interfaces;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.ViewModels.Employes.RequisitiesCRUD
{
    public class CreateRequisitiesViewModel : RequisitiesViewModel, IRoutableViewModel
    {
        public string UrlPathSegment { get { return "CreateEmployee"; } }
        public IScreen HostScreen { get; protected set; }

        public CreateRequisitiesViewModel(
            ILogger<RequisitiesViewModel> logger,
            IRequisitiesViewModelService service,
            IEmployeeBuilder builder,
            IScreen screen = null) : base(logger, service, builder)
        {
            HostScreen = screen;

            CreateRequisiteCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                base.Requisites = new RequisitesItem()
                {
                    AccountNumber = base.AccountNumber,
                    CardType = base.SelectedCardType,
                    Currency = base.SelectedBankCurrency,
                    Division = base.SelectedDivisions,
                    Status = base.SelectedStatus,
                    INN = base.SelectedINN,
                    InsuranceNumber = base.InsuranceNumber,
                    LatinFirstName = base.LatinFirstName,
                    LatinLastName = base.LatinLastName
                };

                await HostScreen.Router.NavigateBack.Execute();

            }, IsValid);
        }


        #region Commands
        public ReactiveCommand<Unit, Unit> CreateRequisiteCommand { get; }
        #endregion

    }
}
