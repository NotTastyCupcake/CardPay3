using Metcom.CardPay3.WebApplication.ViewModels.Employes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WebApplication.Interfaces
{
    public interface IEmployerViewModelService
    {
        public Task<EmployeIndexViewModel> GetEmployers(int pageIndex, int itemsPage, int? organizationId);
        public Task<EmployerViewModel> GetEmploye(int idEmploye);

        public Task<IEnumerable<SelectListItem>> GetOrganizations();
        public Task<IEnumerable<SelectListItem>> GetGenders();
        public Task<IEnumerable<SelectListItem>> GetDocumentTypes();
    }
}
