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
        Task TransferAccrualAsync(string anonymousId, string userName);
        Task<Accrual> AddItemToBasket(string idOrganization, int personId, int payDay, decimal amount, int idTypePay, int idOperationType);
        Task<Accrual> DeleteItem(int personId);
    }
}
