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
        public int PayDay { get; private set; }
        public decimal Amount { get; private set; }
        public int IdPayType { get; private set; }
        public int IdOperationType { get; private set; }

        public AccrualItem(int personId, int payDay, decimal amount, int idTypePay, int idOperationType)
        {
            PersonId = personId;
            Amount = amount;
            IdPayType = idTypePay;
            IdOperationType = idOperationType;
            SetPayDay(payDay);
        }

        private void SetPayDay(int payDay)
        {
            PayDay = payDay;
        }

    }
}
