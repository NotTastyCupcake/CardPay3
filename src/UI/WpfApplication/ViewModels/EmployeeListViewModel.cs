using ReactiveUI;

namespace Metcom.CardPay3.WpfApplication.ViewModels
{
    public class EmployeeListViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment { get { return "EmployeeList"; } }
        public IScreen HostScreen { get; protected set; }
        //TODO: Реализовать список сотрудников
    }
}