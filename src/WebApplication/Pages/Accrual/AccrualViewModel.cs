﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WebApplication.Pages.Accrual
{
    public class AccrualViewModel
    {
        public int Id { get; set; }
        public List<AccrualItemViewModel> Items { get; set; } = new List<AccrualItemViewModel>();
        public int OrganizationId { get; set; }
        public int AccrualDay { get; set; }
        public int IdAccrualType { get; set; }
        public int IdOperationType { get; set; }

        public decimal TotalAmount()
        {
            return Math.Round(Items.Sum(x => x.Amouth), 2);
        }
    }
}