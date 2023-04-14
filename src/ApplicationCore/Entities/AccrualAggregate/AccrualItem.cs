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
        public int IdPerson { get; private set; }
        public PersonItem Person { get; private set; }

        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; } = DateTime.Now;

        public AccrualItem(int personId, decimal amount)
        {
            IdPerson = personId;
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
