using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }
    }
}
