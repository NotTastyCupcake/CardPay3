using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WebApplication.ViewModels.Employes
{
    public class EmployeRequisitesViewModel
    {
        public int IdDivision { get; set; }
        public int IdCurrency { get; set; }


        public int INN { get; set; }
        /// <summary>
        /// Страховой номер
        /// </summary>
        public string InsuranceNumber { get; set; }

        /// <summary>
        /// Имя в латинице
        /// </summary>
        public string LatinFirstName { get; set; }
        /// <summary>
        /// Фамилия в латинице
        /// </summary>
        public string LatinLastName { get; set; }
        public string CardNumber { get; set; }
        //public string AccountNumber { get; set; }
        public int IdCardType { get; set; }
    }
}