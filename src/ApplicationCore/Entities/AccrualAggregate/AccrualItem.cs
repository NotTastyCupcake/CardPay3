using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate
{
    public class AccrualItem : BaseEntity
    {
        public int PersonId { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime Date => DateTime.Now;

        public AccrualItem(int personId, decimal amount)
        {
            PersonId = personId;
            SetAmount(amount);
        }

        public void SetAmount(decimal amount)
        {
            Guard.Against.OutOfRange(amount, nameof(amount), 0, decimal.MaxValue);
            Amount = amount;
        }

    }
}
