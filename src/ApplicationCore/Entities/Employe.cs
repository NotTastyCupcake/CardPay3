using Ardalis.GuardClauses;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Entities
{
    public class Employe : BaseEntity
    {

        public Employe(
            string lastName,  
            string firstName, 
            string middleName,
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
            PhoneNumber = phoneNum;
            JobPhoneNumber = jobPhoneNum;
            Position = position;
            DepartmentNum = departmentNum;
            IdGender = genderId;
            IdDocument = documentId;
            IdOrganization = organizationId;
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

        #region Контактные данные
        public string PhoneNumber { get; private set; }
        public string JobPhoneNumber { get; private set; }
        public string Position { get; private set; }
        public string DepartmentNum { get; private set; }
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

        public virtual ICollection<Address> Addresses { get; set; }

        public int? IdOrganization { get; set; }
        public virtual Organization? Organization { get; set; }
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
