using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
