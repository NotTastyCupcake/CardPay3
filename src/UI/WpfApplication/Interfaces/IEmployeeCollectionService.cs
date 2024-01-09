using DynamicData;
using Metcom.CardPay3.ApplicationCore.Entities;

namespace Metcom.CardPay3.WpfApplication.Interfaces
{
    public interface IEmployeeCollectionService
    {
        SourceCache<Employee, int> All { get; }
    }
}
