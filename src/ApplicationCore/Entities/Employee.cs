﻿using Ardalis.GuardClauses;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using System;
using System.Collections.Generic;

namespace Metcom.CardPay3.ApplicationCore.Entities
{
    public class Employee : BaseEntity
    {
        public Employee()
        {

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
        /// Реквизиты счета, данные для открытия
        /// </summary>
        public int IdRequisite { get; set; }
        /// <summary>
        /// Реквизиты счета, данные для открытия
        /// </summary>
        public virtual RequisitesItem Requisite { get; set; }

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

    }
}
