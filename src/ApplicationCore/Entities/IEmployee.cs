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
        DateTime BirthdayDate { get; }
        string BonusNumber { get; set; }
        string DepartmentNum { get; }
        DocumentItem Document { get; set; }
        string EMail { get; set; }
        string FirstName { get; }
        string FullName { get; }
        Gender Gender { get; set; }
        int? IdDocument { get; set; }
        int IdGender { get; }
        int IdOrganization { get; set; }
        int IdType { get; set; }
        string JobPhoneNumber { get; }
        string LastName { get; }
        string MiddleName { get; }
        string Nationality { get; }
        Organization Organization { get; set; }
        string PhoneNumber { get; }
        string Position { get; }
        ICollection<RequisitesItem> Requisites { get; set; }
        bool Resident { get; }
        EmployeeType Type { get; set; }

    }
}