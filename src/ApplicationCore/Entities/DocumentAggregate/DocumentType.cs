using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate
{
    public class DocumentType : BaseEntity
    {
        public string DocumentName { get; private set; }
        public DocumentType(string name)
        {
            DocumentName = name;
        }

        public DocumentType()
        {
            // required by EF
        }
    }
}
