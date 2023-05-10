using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WebApplication.ViewModels.Employe
{
    public class EmployerDitalesViewModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        public string PhoneNumber { get; set; }
        public string JobPhoneNumber { get; set; }
        public string Position { get; set; }
        public string DepartmentNum { get; set; }
        public string Gender { get; set; }

        public string NameOrganization { get; }
    }
}
