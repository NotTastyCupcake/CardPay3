using Castle.Core.Logging;
using Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;
using ReactiveUI;

namespace Metcom.CardPay3.WpfApplication.ViewModels
{
    public class AccrualListViewModel : ReactiveObject, IRoutableViewModel
    {
        private readonly ILogger<AccrualListViewModel> _logger;
        private readonly IRepository<Accrual> _repositoryAccrual;

        public string UrlPathSegment { get { return "AccrualList"; } }
        public IScreen HostScreen { get; protected set; }

        public AccrualListViewModel(
            ILogger<AccrualListViewModel> logger,
            IRepository<Accrual> repositoryAccrual,
            IScreen screen = null
            )
        {
            _logger = logger;
            _repositoryAccrual = repositoryAccrual;

            HostScreen = screen;
        }
    }
}