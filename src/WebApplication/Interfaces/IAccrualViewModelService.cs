using Metcom.CardPay3.WebApplication.Pages.Accrual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WebApplication.Interfaces
{
    public interface IAccrualViewModelService
    {
        Task<AccrualViewModel> GetOrCreateAsyncAccrualForUser(string userName);
    }
}
