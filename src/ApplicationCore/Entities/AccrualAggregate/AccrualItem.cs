using Ardalis.GuardClauses;
using System;

namespace Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate
{
    public class AccrualItem : BaseEntity, IAccrualItem
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
        public AccrualItem(IAccrualItem item)
        {
            IdEmployee = item.IdEmployee;
            SetAmount(item.Amount);
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
