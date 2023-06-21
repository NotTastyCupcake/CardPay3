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
        public int? IdEmployer { get; private set; }
        public virtual Employe? Employer { get; private set; }

        public RequisitesItem()
        {
            //requared for EF
        }

        public RequisitesItem(string latinFirstName, 
            string latinLastName, 
            string cardNumber,
            string accountNumber,
            int idCardType, 
            int inn, 
            string insuranceNum, 
            int idDivision, 
            int idCurrency,
            int idEmployer
            )
        {
            LatinFirstName = latinFirstName;
            LatinLastName = latinLastName;
            CardNumber = cardNumber;
            AccountNumber = accountNumber;
            IdCardType = idCardType;
            INN = inn;
            InsuranceNumber = insuranceNum;
            IdDivision = idDivision;
            IdCurrency = idCurrency;
            IdEmployer = idEmployer;
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
        public string CardNumber { get; private set; }
        public string AccountNumber { get; private set; }
        public virtual BankCardType? CardType { get; private set; }
        public int IdCardType { get; private set; }
        #endregion

        //TODO: Создать поле статуса передачи реквезитов

        public void UpdateCard(string lastName, string firstName, string cardNumber, string accountNumber, int idCardType)
        {
            Guard.Against.NullOrEmpty(lastName, nameof(lastName));
            Guard.Against.NullOrEmpty(firstName, nameof(firstName));

            Guard.Against.NullOrEmpty(cardNumber, nameof(cardNumber));
            Guard.Against.NullOrEmpty(accountNumber, nameof(accountNumber));
            Guard.Against.OutOfRange(idCardType, nameof(idCardType), 0, int.MaxValue);

            LatinLastName = lastName;
            LatinFirstName = firstName;

            CardNumber = cardNumber;
            AccountNumber = accountNumber;
            IdCardType = idCardType;
        }

    }
}
