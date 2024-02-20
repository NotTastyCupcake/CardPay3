using System;

namespace Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate
{
    public class BankCurrency : BaseEntity
    {
        public BankCurrency(string name, string code)
        {
            NameCurrency = name;
            Code = code;
        }

        /// <summary>
        /// Название валюты
        /// </summary>
        public string NameCurrency { get; private set; }

        /// <summary>
        /// Название валюты
        /// </summary>
        public string Code { get; private set; }

        [Obsolete]
        public BankCurrency()
        {
            //requared for EF
        }
    }
}
