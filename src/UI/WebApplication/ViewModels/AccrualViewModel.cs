using System;
using System.Collections.Generic;
using System.Linq;

namespace Metcom.CardPay3.WebApplication.ViewModels
{
    public class AccrualViewModel
    {
        public int Id { get; set; }
        public List<AccrualItemViewModel> Items { get; set; } = new List<AccrualItemViewModel>();
        public int OrganizationId { get; set; }
        public DateTime AccrualDay { get; set; }
        public int IdAccrualType { get; set; }
        public int IdOperationType { get; set; }

        public decimal TotalAmount()
        {
            return Math.Round(Items.Sum(x => x.Amount), 2);
        }
    }
}
