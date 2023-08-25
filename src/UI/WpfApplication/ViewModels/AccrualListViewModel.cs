using ReactiveUI;

namespace Metcom.CardPay3.WpfApplication.ViewModels
{
    public class AccrualListViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment { get { return "AccrualList"; } }
        public IScreen HostScreen { get; protected set; }
    }
}