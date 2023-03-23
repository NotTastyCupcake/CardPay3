using Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Interfaces
{
    public interface IAccrualService
    {
        Task TransferAccrualAsync(int oldIdOrganization, int newIdOrganization);
        Task<Accrual> AddItemToAccrual(int idOrganization, int personId, int accrualDay, decimal amount, int idAccrualType, int idOperationType);
        Task<Accrual> DeleteItem(int accrualId, int personId);
        Task<Accrual> SetAmounts(int accrualId, Dictionary<string, decimal> amounts);
        Task DeleteAccrual(int accrualId);

    }
}
