using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using Metcom.CardPay3.ApplicationCore.Entities;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.Models
{
    public class EmployeeModel
    {

        [Reactive]
        public ICollection<Address> Addresses { get; set; }
        [Reactive]
        public DateTime? BirthdayDate { get; set; }
        [Reactive]
        public string BonusNumber { get; set; }
        [Reactive]
        public string DepartmentNum { get; set; }
        [Reactive]
        public DocumentItem Document { get; set; }
        [Reactive]
        public int IdDocument { get; set; }
        [Reactive]
        public string EMail { get; set; }
        [Reactive]
        public string FirstName { get; set; }
        [Reactive]
        public string LastName { get; set; }
        [Reactive]
        public string MiddleName { get; set; }
        [Reactive]
        public Gender Gender { get; set; }
        [Reactive]
        public int IdGender { get; set; }
        [Reactive]
        public string JobPhoneNumber { get; set; }
        [Reactive]
        public string Nationality { get; set; }
        [Reactive]
        public string PhoneNumber { get; set; }
        [Reactive]
        public string Position { get; set; }
        [Reactive]
        public ICollection<RequisitesItem> Requisites { get; set; }
        [Reactive]
        public bool Resident { get; set; }
        [Reactive]
        public EmployeeType Type { get; set; }
        [Reactive]
        public int IdType { get; set; }
    }
}
