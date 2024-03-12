using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.Interfaces
{
    public interface IRequisitiesViewModelService
    {
        Task<ReadOnlyCollection<BankCardType>> GetTypes();
        Task<ReadOnlyCollection<BankCurrency>> GetCurrencies();
        Task<ReadOnlyCollection<BankDivision>> GetDivisions();
        Task<ReadOnlyCollection<Status>> GetStatuses();
    }
}
