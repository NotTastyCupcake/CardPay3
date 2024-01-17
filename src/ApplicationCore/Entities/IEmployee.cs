using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using System;
using System.Collections.Generic;

namespace Metcom.CardPay3.ApplicationCore.Entities
{
    public interface IEmployee
    {
        ICollection<Address> Addresses { get; set; }
        DateTime BirthdayDate { get; set; }
        string BonusNumber { get; set; }
        string DepartmentNum { get; set; }
        string EMail { get; set; }
        string FirstName { get; set; }
        public string FullName => $"{LastName} {FirstName} {MiddleName}";
        int? IdDocument { get; set; }
        int IdGender { get; set; }
        int IdOrganization { get; set; }
        int? IdType { get; set; }
        string JobPhoneNumber { get; set; }
        string LastName { get; set;  }
        string MiddleName { get; set; }
        string Nationality { get; set; }
        string PhoneNumber { get; set; }
        string Position { get; set; }
        ICollection<RequisitesItem> Requisites { get; set; }
        bool Resident { get; set; }

    }
}