using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces.Builder;
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
            IRepository<RequisitesItem> repository, 
            IRepository<BankCardType> typeRepository, 
            IRepository<BankCurrency> currencyRepository, 
            IRepository<BankDivision> divisionRepository, 
            IRepository<Status> statusRepository,
            IEmployeeBuilder builder,
            IScreen screen = null) : base(logger, repository, typeRepository, currencyRepository, divisionRepository, statusRepository, builder)
        {
            HostScreen = screen;

            CreateRequisiteCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                Item = new RequisitesItem(this);
                await HostScreen.Router.NavigateBack.Execute();

            }, IsValid);
        }


        #region Commands
        public ReactiveCommand<Unit, Unit> CreateRequisiteCommand { get; }
        #endregion
        [Reactive]
        public RequisitesItem Item { get; set; }

    }
}
