using Ardalis.GuardClauses;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Entities.PersonAggregate
{
    public class PersonItem : BaseEntity, IAggregateRoot
    {

        public PersonItem(
            int idPerson,
            string lastName,
            string firstName,
            string middleName,
            string latinFirstName,
            string latinLastName,
            int genderId,
            int documentId,
            int requestId)
        {
            Id = idPerson;
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;

            LatinFirstName = latinFirstName;
            LatinLastName = latinLastName;

            IdGender = genderId;
            IdDocument = documentId;
            IdRequisties = requestId;
        }

        #region ФИО Сотрудника
        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public string MiddleName { get; private set; } 
        #endregion

        #region Данные отображения на карте сотрудника
        /// <summary>
        /// Имя в латинице
        /// </summary>
        public string LatinFirstName { get; private set; }
        /// <summary>
        /// Фамилия в латинице
        /// </summary>
        public string LatinLastName { get; private set; } 
        #endregion

        public string PhoneNumber { get; set; }

        #region Ссылка на объект
        public int IdGender { get; private set; }
        public PersonGender Gender { get; private set; }
        public int IdDocument { get; set; }
        public PersonDocument Document { get; set; }
        public int IdAddress { get; set; }
        public Address Address { get; set; }
        /// <summary>
        /// Реквизиты документов человека
        /// </summary>
        public int IdRequisties { get; set; }
        /// <summary>
        /// Реквизиты документов человека
        /// </summary>
        public PersonRequisites Requisites { get; set; } 
        #endregion

        public void UpdateFullName(string lastName, string firstName, string middleName)
        {
            Guard.Against.NullOrEmpty(lastName, nameof(lastName));
            Guard.Against.NullOrEmpty(firstName, nameof(firstName));
            Guard.Against.NullOrEmpty(middleName, nameof(middleName));

            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
        }


        public void UpdateNameCard(string lastName, string firstName)
        {
            Guard.Against.NullOrEmpty(lastName, nameof(lastName));
            Guard.Against.NullOrEmpty(firstName, nameof(firstName));
            
            LatinLastName = lastName;
            LatinFirstName = firstName;
        }
    }
}
