using System;

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
