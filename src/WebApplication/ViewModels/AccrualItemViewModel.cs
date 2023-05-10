using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WebApplication.ViewModels
{
    public class AccrualItemViewModel
    {
        public int Id { get; set; }
        public int EmployerId { get; set; }
        public string FullName { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
