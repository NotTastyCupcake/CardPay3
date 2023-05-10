using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate
{
    public class BankCardType : BaseEntity
    {
        public BankCardType(string nameType)
        {
            NameType = nameType;
        }
        public BankCardType()
        {

        }
        public string NameType { get; set; }
    }
}
