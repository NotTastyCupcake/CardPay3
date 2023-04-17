using Metcom.CardPay3.WebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WebApplication.Interfaces
{
    public interface IPersonViewModelService
    {
        public Task<PersonIndexViewModel> GetEmployers(int pageIndex, int itemsPage, int? organizationId);

        public Task<IEnumerable<SelectListItem>> GetOrganizations();
        public Task<IEnumerable<SelectListItem>> GetGroups();
    }
}
