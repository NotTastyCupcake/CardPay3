using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.Interfaces
{
    /// <summary>
    /// Сервис управление сотрудником
    /// </summary>
    public interface IEmployeeViewModelService
    {
        Task<ReadOnlyObservableCollection<Gender>> GetGenders();
        ObservableCollection<Address> GetAddress(Employee employee);
        ObservableCollection<RequisitesItem> GetRequisites(Employee employee);
    }
}
