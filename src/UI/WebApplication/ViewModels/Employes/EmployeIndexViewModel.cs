using Metcom.CardPay3.ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
