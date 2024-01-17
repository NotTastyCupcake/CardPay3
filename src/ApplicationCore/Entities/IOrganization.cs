using System;
using System.Collections.Generic;

namespace Metcom.CardPay3.ApplicationCore.Entities
{
    public interface IOrganization
    {
        string Account { get; set; }
        DateTime? ApplicationDate { get; set; }
        string ApplicationNumber { get; }
        string BankCode { get; set; }
        DateTime? CreateDate { get; }
        string INN { get; set; }
        string Name { get; }
        string SourceId { get; }
    }
}