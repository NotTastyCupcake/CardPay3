using Ardalis.GuardClauses;
using System;

namespace Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate
{
    public class RequisitesItem : BaseEntity, IRequisitesItem
    {
#nullable enable
        public int IdEmployer { get; set; }
        public virtual Employee Employee { get; set; }
#nullable disable

        public RequisitesItem(int inn,
                              string insuranceNum,
                              int idDivision,
                              int idCurrency,
                              int idCardType,
                              int idStatus,

                              string latinFirstName = null,
                              string latinLastName = null
                              )
        {
            INN = inn;
            InsuranceNumber = insuranceNum;
            IdDivision = idDivision;
            IdCurrency = idCurrency;
            IdCardType = idCardType;
            IdStatus = idStatus;

            LatinFirstName = latinFirstName;
            LatinLastName = latinLastName;
        }

        public RequisitesItem(IRequisitesItem item)
        {
            AccountNumber = item.AccountNumber;
            IdCardType = item.IdCardType;
            IdCurrency = item.IdCurrency;
            IdDivision = item.IdDivision;
            INN = item.INN;
            InsuranceNumber = item.InsuranceNumber;
            LatinFirstName = item.LatinFirstName;
            LatinLastName = item.LatinLastName;
            IdStatus = item.IdStatus;
        }

        [Obsolete]
        public RequisitesItem()
        {
            // required by EF
        }

        public virtual BankDivision Division { get; set; }
        public int IdDivision { get; set; }
        public virtual BankCurrency Currency { get; set; }
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
