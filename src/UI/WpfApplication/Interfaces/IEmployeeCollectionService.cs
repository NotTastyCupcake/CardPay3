using DynamicData;
using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.WpfApplication.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.Interfaces
{
    public interface IEmployeeCollectionService
    {
        SourceCache<SelectableItemWrapper<Employee>, int> All { get; }
        Task LoadOrUpdateEmployeesCollection();

        Task<ReadOnlyCollection<Status>> GetStatusesCollection();
    }
}
