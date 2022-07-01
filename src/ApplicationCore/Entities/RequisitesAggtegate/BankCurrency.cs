using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate
{
    public class BankCurrency : BaseEntity
    {
        /// <summary>
        /// Название валюты
        /// </summary>
        public string NameCurrency { get; set; }
    }
}
