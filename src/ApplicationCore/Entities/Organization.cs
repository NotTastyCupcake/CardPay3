using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;

namespace Metcom.CardPay3.ApplicationCore.Entities
{
    public class Organization : BaseEntity
    {

        public virtual ICollection<Employee> Employees { get; private set; }

        /// <summary>
        /// Дата формирования
        /// </summary>
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }
        public string INN { get; set; }
        /// <summary>
        /// Номер договора
        /// </summary>
        public string ApplicationNumber { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Account { get; set; }
        /// <summary>
        /// Рекомендуется заполнять. БИК банка, с которым заключен зарплатный договор
        /// </summary>
        public string BankCode { get; set; }
        /// <summary> 
        /// Ид первичного документа
        /// </summary>
        public string SourceId { get; set; }

        public Organization(string name)
        {
            Name = name;
        }

        public Organization()
        {

        }

        public void UpdateNameGroup(string newNameOrganization)
        {
            Guard.Against.NullOrEmpty(newNameOrganization, nameof(newNameOrganization));

            Name = newNameOrganization;
        }
    }
}
