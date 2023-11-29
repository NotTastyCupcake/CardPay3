using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Metcom.CardPay3.WebApplication.ViewModels.Employes
{
    public class EmployeIndexViewModel
    {
        public IEnumerable<EmployerItemViewModel> Employers { get; set; }

        public IEnumerable<SelectListItem> Organization { get; set; }

        public int? OrganizationFilterApplied { get; set; }

        public PaginationInfoViewModel PaginationInfo { get; set; }
    }
}
