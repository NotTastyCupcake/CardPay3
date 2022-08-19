using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Entities.GroupAggregate
{
    public class GroupItem
    {
        public int PersonId { get; private set; }
        public GroupItem(int personItemId)
        {
            PersonId = personItemId;
        }
    }
}
