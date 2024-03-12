using Ardalis.GuardClauses;
using System;

namespace Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate
{
    public class AccrualItem : BaseEntity
    {
        public int IdEmployee { get; private set; }
        public virtual Employee Employee { get; private set; }

        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; } = DateTime.Now;

        //TODO: Создать поле статуса платежа

        public AccrualItem(int employerId, decimal amount)
        {
            IdEmployee = employerId;
            SetAmount(amount);
        }

        public AccrualItem()
        {
            // required by EF
        }

        public void SetAmount(decimal amount)
        {
            Guard.Against.OutOfRange(amount, nameof(amount), 0, decimal.MaxValue);
            Amount = amount;
        }

    }
}
