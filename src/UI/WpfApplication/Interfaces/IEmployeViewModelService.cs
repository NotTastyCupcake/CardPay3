using DynamicData;
using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.Interfaces
{
    /// <summary>
    /// Сервис управление сотрудником
    /// </summary>
    public interface IEmployeViewModelService
    {
        Task<ReadOnlyObservableCollection<Gender>> GetGenders();
        ObservableCollection<Address> GetAddress(Employe employe);
        ObservableCollection<RequisitesItem> GetRequisites(Employe employe);
    }
}
