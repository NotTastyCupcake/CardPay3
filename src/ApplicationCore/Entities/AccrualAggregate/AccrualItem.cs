using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate
{
    public class AccrualItem
    {
        public DateTime PayDay { get; private set; }
        public int PersonId { get; set; }

        public AccrualItem(int personId)
        {
            PersonId = personId;
        }

    }
}
