using Metcom.CardPay3.WebApplication.ViewModels;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WebApplication.Interfaces
{
    public interface IAccrualViewModelService
    {
        Task<AccrualViewModel> GetOrCreateAsyncAccrualForUser(string userName);
    }
}
