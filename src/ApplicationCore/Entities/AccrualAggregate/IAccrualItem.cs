using System;

namespace Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate
{
    public interface IAccrualItem
    {
        decimal Amount { get; }
        DateTime Date { get; }
        Employee Employee { get; }
        int IdEmployee { get; }

    }
}