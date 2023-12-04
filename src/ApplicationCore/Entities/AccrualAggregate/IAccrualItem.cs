using System;

namespace Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate
{
    public interface IAccrualItem
    {
        decimal Amount { get; }
        DateTime Date { get; }
        Employe Employer { get; }
        int IdEmployer { get; }

    }
}