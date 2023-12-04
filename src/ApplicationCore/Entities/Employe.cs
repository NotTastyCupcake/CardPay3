using Ardalis.GuardClauses;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using System;
using System.Collections.Generic;

namespace Metcom.CardPay3.ApplicationCore.Entities
{
    public class Employe : BaseEntity, IEmploye
    {

        public Employe(
            string lastName,
            string firstName,
            string middleName,
            DateTime birthdayDate,
            string nationality,
            bool resident,
            string phoneNum,
            string jobPhoneNum,
            string position,
            string departmentNum,
            int genderId,
            int documentId,
            int organizationId)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            BirthdayDate = birthdayDate;
            Resident = resident;
            Nationality = nationality;
            PhoneNumber = phoneNum;
            JobPhoneNumber = jobPhoneNum;
            Position = position;
            DepartmentNum = departmentNum;
            IdGender = genderId;
            IdDocument = documentId;
            IdOrganization = organizationId;
        }

        public Employe(IEmploye employe)
        {
            LastName = employe.LastName;
            FirstName = employe.FirstName;
            MiddleName = employe.MiddleName;
            BirthdayDate = employe.BirthdayDate;
            Resident = employe.Resident;
            Nationality = employe.Nationality;
            PhoneNumber = employe.PhoneNumber;
            JobPhoneNumber = employe.JobPhoneNumber;
            Position = employe.Position;
            DepartmentNum = employe.DepartmentNum;
            IdGender = employe.IdGender;
            IdDocument = employe.IdDocument;
            IdOrganization = employe.IdOrganization;
        }

        public Employe()
        {
            // required by EF
        }

        #region ФИО Сотрудника
        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }

        public string FullName => $"{LastName} {FirstName} {MiddleName}";
        #endregion

        public DateTime BirthdayDate { get; private set; }
        /// <summary>
        /// Резидентность
        /// </summary>
        public bool Resident { get; private set; }
        /// <summary>
        /// Гражданство
        /// </summary>
        public string Nationality { get; private set; }

        /// <summary>
        /// Номер участника в бонус программе.
        /// </summary>
        public string BonusNumber { get; set; }


        #region Контактные данные
        /// <summary>
        /// Личный телефон
        /// </summary>
        public string PhoneNumber { get; private set; }
        /// <summary>
        /// Рабочий телефон
        /// </summary>
        public string JobPhoneNumber { get; private set; }
        public string Position { get; private set; }
        public string DepartmentNum { get; private set; }
        public string EMail { get; set; }
        #endregion

        #region Ссылка на объект
#nullable enable
        public int IdGender { get; private set; }
        public virtual Gender Gender { get; set; }

        /// <summary>
        /// Реквизиты документов человека
        /// </summary>
        public virtual ICollection<RequisitesItem> Requisites { get; set; }

        public int? IdDocument { get; set; }
        public virtual DocumentItem? Document { get; set; }

        public int IdJobAddress { get; set; }
        /// <summary>
        /// Адрес места работы
        /// </summary>
        public virtual Address JobAddress { get; set; }

        public int IdBirthdayAddress { get; set; }
        /// <summary>
        /// Место рождения
        /// </summary>
        public virtual Address BirthdayAddress { get; set; }

        public int IdLegalAddress { get; set; }
        public Address LegalAddress { get; set; }

        public int IdPostAddress { get; set; }
        public Address PostAddress { get; set; }

        public int IdOrganization { get; set; }
        public virtual Organization Organization { get; set; }


        public int IdType { get; set; }
        /// <summary>
        /// Категория населения
        /// </summary>
        public EmployeType Type { get; set; }
#nullable disable
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

        public void UpdateContactDetails(string phoneNum, string jobPhoneNum, string position, string departmentNum)
        {
            Guard.Against.NullOrEmpty(phoneNum, nameof(phoneNum));
            Guard.Against.NullOrEmpty(jobPhoneNum, nameof(jobPhoneNum));
            Guard.Against.NullOrEmpty(position, nameof(position));
            Guard.Against.NullOrEmpty(departmentNum, nameof(departmentNum));

            PhoneNumber = phoneNum;
            JobPhoneNumber = jobPhoneNum;
            Position = position;
            DepartmentNum = departmentNum;
        }

    }
}
