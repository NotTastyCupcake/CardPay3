using Ardalis.GuardClauses;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using System;
using System.Collections.Generic;

namespace Metcom.CardPay3.ApplicationCore.Entities
{
    public class Employee : BaseEntity, IEmployee
    {

        public Employee(
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

        public Employee(IEmployee employee)
        {
            LastName = employee.LastName;
            FirstName = employee.FirstName;
            MiddleName = employee.MiddleName;
            BirthdayDate = employee.BirthdayDate;
            Resident = employee.Resident;
            Nationality = employee.Nationality;
            PhoneNumber = employee.PhoneNumber;
            JobPhoneNumber = employee.JobPhoneNumber;
            Position = employee.Position;
            DepartmentNum = employee.DepartmentNum;
            IdGender = employee.IdGender;
            IdDocument = employee.IdDocument;
            IdOrganization = employee.IdOrganization;
        }

        public Employee()
        {
            // required by EF
        }

        #region ФИО Сотрудника
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        public string FullName => $"{LastName} {FirstName} {MiddleName}";
        #endregion

        public DateTime BirthdayDate { get; set; }
        /// <summary>
        /// Резидентность
        /// </summary>
        public bool Resident { get; set; }
        /// <summary>
        /// Гражданство
        /// </summary>
        public string Nationality { get; set; }

        /// <summary>
        /// Номер участника в бонус программе.
        /// </summary>
        public string BonusNumber { get; set; }


        #region Контактные данные
        /// <summary>
        /// Личный телефон
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Рабочий телефон
        /// </summary>
        public string JobPhoneNumber { get; set; }
        public string Position { get; set; }
        public string DepartmentNum { get; set; }
        public string EMail { get; set; }
        #endregion

        #region Ссылка на объект
#nullable enable
        public int IdGender { get; set; }
        public virtual Gender Gender { get; set; }

        /// <summary>
        /// Реквизиты документов человека
        /// </summary>
        public virtual ICollection<RequisitesItem> Requisites { get; set; }

        public int? IdDocument { get; set; }
        public virtual DocumentItem? Document { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public int IdOrganization { get; set; }
        public virtual Organization Organization { get; set; }


        public int? IdType { get; set; }
        /// <summary>
        /// Категория населения
        /// </summary>
        public virtual EmployeeType? Type { get; set; }
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
