﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WebApplication.Pages.Accrual
{
    public class AccrualItemViewModel
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string FullName { get; set; }
        public decimal Amouth { get; set; }
        public DateTime Date { get; set; }
    }
}