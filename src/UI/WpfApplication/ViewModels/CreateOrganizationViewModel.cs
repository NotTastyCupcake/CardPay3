using ReactiveUI;

namespace Metcom.CardPay3.WpfApplication.ViewModels
{
    public class CreateOrganizationViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment { get { return "CreateOrganization"; } }
        public IScreen HostScreen { get; protected set; }
        //TODO: Реализовать создание организации
    }
}