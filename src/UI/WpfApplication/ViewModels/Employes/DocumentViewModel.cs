using ReactiveUI;

namespace Metcom.CardPay3.WpfApplication.ViewModels.Employes
{
    public class DocumentViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment { get { return "Document"; } }
        public IScreen HostScreen { get; protected set; }
        public DocumentViewModel(IScreen screen = null)
        {
            HostScreen = screen;
        }
        //TODO: Создать ViewModel для просмотра/редактирвоания/создания документов
    }
}
