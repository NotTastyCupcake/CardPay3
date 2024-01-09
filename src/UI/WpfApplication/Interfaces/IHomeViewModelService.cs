using Metcom.CardPay3.ApplicationCore.Entities;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.Interfaces
{
    public interface IHomeViewModelService
    {
        public Task<ObservableCollection<Organization>> GetOrganizations();
    }
}
