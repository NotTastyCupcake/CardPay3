using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate
{
    public class RequisitesItem : BaseEntity
    {
        public BankDivision Division { get; set; }
        public int IdDivision { get; set; }
        public BankCurrency Currency { get; set; }
        public int IdCurrency { get; set; }
        

        public int INN { get; set; }
        /// <summary>
        /// Страховой номер
        /// </summary>
        public string InsuranceNumber { get; set; }

        #region Данные о карте сотрудника
        /// <summary>
        /// Имя в латинице
        /// </summary>
        public string LatinFirstName { get; set; }
        /// <summary>
        /// Фамилия в латинице
        /// </summary>
        public string LatinLastName { get; set; }
        public string CardNumber { get; set; }
        public int AccountNumber { get; set; }
        public BankCardType CardType { get; set; }
        public int IdCardType { get; set; }
        #endregion

        public void UpdateNameCard(string lastName, string firstName)
        {
            Guard.Against.NullOrEmpty(lastName, nameof(lastName));
            Guard.Against.NullOrEmpty(firstName, nameof(firstName));

            LatinLastName = lastName;
            LatinFirstName = firstName;
        }
    }
}
