using Ardalis.GuardClauses;
using System;

namespace Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate
{
    public class RequisitesItem : BaseEntity
    {
#nullable enable
        public int IdEmployer { get; set; }
        public virtual Employee Employee { get; set; }
#nullable disable

        public RequisitesItem()
        {

        }

        public string FullName => $"{CardType.NameType}: {AccountNumber}";

        public virtual BankDivision Division { get; set; }
        public int IdDivision { get; set; }
        public virtual BankCurrency Currency { get; set; }
        public int IdCurrency { get; set; }


        public int? INN { get; set; }
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
        public string AccountNumber { get; set; }

        public virtual BankCardType CardType { get; set; }
        public int IdCardType { get; set; }

        #endregion

        public virtual Status Status { get; set; }
        public int IdStatus { get; set; }

        public void UpdateCard(string accountNumber, int idCardType)
        {
            Guard.Against.NullOrEmpty(accountNumber, nameof(accountNumber));
            Guard.Against.OutOfRange(idCardType, nameof(idCardType), 0, int.MaxValue);

            AccountNumber = accountNumber;
            IdCardType = idCardType;
        }

        public void FullUpdateCardData(string lastName, string firstName, string accountNumber, int idCardType)
        {
            Guard.Against.NullOrEmpty(lastName, nameof(lastName));
            Guard.Against.NullOrEmpty(firstName, nameof(firstName));

            Guard.Against.NullOrEmpty(accountNumber, nameof(accountNumber));
            Guard.Against.OutOfRange(idCardType, nameof(idCardType), 0, int.MaxValue);

            LatinLastName = lastName;
            LatinFirstName = firstName;

            AccountNumber = accountNumber;
            IdCardType = idCardType;
        }

    }
}
