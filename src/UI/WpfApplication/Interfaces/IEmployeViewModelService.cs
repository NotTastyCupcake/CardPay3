using DynamicData;
using Metcom.CardPay3.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.Interfaces
{
    public interface IEmployeViewModelService
    {
        Task<IObservableCache<Employe, int>> GetEmployes(int? organizationId);
        Task<ReadOnlyObservableCollection<Gender>> GetGenders();
    }
}
