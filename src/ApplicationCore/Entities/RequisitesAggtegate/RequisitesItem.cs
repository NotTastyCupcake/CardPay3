using Ardalis.GuardClauses;
using System;

namespace Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate
{
    public class RequisitesItem : BaseEntity, IRequisitesItem
    {
#nullable enable
        public int? IdEmployer { get; set; }
        public virtual Employee? Employee { get; set; }
#nullable disable

        public RequisitesItem(int inn,
                              string insuranceNum,
                              int idDivision,
                              int idCurrency,
                              int? idCardType,

                              string latinFirstName = null,
                              string latinLastName = null
                              )
        {
            INN = inn;
            InsuranceNumber = insuranceNum;
            IdDivision = idDivision;
            IdCurrency = idCurrency;
            IdCardType = idCardType;

            LatinFirstName = latinFirstName;
            LatinLastName = latinLastName;

            Status = Status.New;
        }

        public RequisitesItem(IRequisitesItem item)
        {
            AccountNumber = item.AccountNumber;
            CardType = item.CardType;
            Currency = item.Currency;
            Division = item.Division;
            Employee = item.Employee;
            IdCardType = item.IdCardType;
            IdCurrency = item.IdCurrency;
            IdDivision = item.IdDivision;
            IdEmployer = item.IdEmployer;
            INN = item.INN;
            InsuranceNumber = item.InsuranceNumber;
            LatinFirstName = item.LatinFirstName;
            LatinLastName = item.LatinLastName;
            Status = item.Status;
        }

        [Obsolete]
        public RequisitesItem()
        {
            // required by EF
        }

        public virtual BankDivision Division { get; private set; }
        public int IdDivision { get; private set; }
        public virtual BankCurrency Currency { get; private set; }
        public int IdCurrency { get; private set; }


        public int INN { get; private set; }
        /// <summary>
        /// Страховой номер
        /// </summary>
        public string InsuranceNumber { get; private set; }

        #region Данные о карте сотрудника
        /// <summary>
        /// Имя в латинице
        /// </summary>
        public string LatinFirstName { get; private set; }
        /// <summary>
        /// Фамилия в латинице
        /// </summary>
        public string LatinLastName { get; private set; }
        public string AccountNumber { get; private set; }

#nullable enable
        public virtual BankCardType? CardType { get; private set; }
        public int? IdCardType { get; private set; }
#nullable disable

        #endregion

        public Status Status { get; set; }

        public void UpdateCard(string accountNumber, int idCardType)
        {
            Guard.Against.NullOrEmpty(accountNumber, nameof(accountNumber));
            Guard.Against.OutOfRange(idCardType, nameof(idCardType), 0, int.MaxValue);

            AccountNumber = accountNumber;
            IdCardType = idCardType;

            Status = Status.Success;
        }

        public void UpdateStatus(Status status)
        {
            Status = status;
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
