using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using System;
using System.Collections.Generic;

namespace Metcom.CardPay3.ApplicationCore.Entities
{
    public interface IEmploye
    {
        Address BirthdayAddress { get; }
        DateTime BirthdayDate { get; }
        string BonusNumber { get; }
        string DepartmentNum { get; }
        DocumentItem Document { get; }
        string EMail { get; }
        string FirstName { get; }
        string FullName { get; }
        Gender Gender { get; }
        int IdBirthdayAddress { get; }
        int? IdDocument { get; }
        int IdGender { get; }
        int IdJobAddress { get; }
        int IdLegalAddress { get; }
        int IdOrganization { get; }
        int IdPostAddress { get; }
        int IdType { get; }
        Address JobAddress { get; }
        string JobPhoneNumber { get; }
        string LastName { get; }
        Address LegalAddress { get; }
        string MiddleName { get; }
        string Nationality { get; }
        Organization Organization { get; }
        string PhoneNumber { get; }
        string Position { get; }
        Address PostAddress { get; }
        ICollection<RequisitesItem> Requisites { get;}
        bool Resident { get; }
        EmployeType Type { get; }

    }
}