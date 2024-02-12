using DynamicData;
using Metcom.CardPay3.ApplicationCore.Entities;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.Interfaces
{
    public interface IEmployeeCollectionService
    {
        SourceCache<Employee, int> All { get; }
        Task LoadOrUpdateEmployeesCollection();
    }
}
