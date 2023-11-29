using System.Collections.Generic;

namespace Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate
{
    public class DocumentType : BaseEntity
    {
        public string DocumentName { get; private set; }
        public DocumentType(string name)
        {
            DocumentName = name;
        }

        public virtual ICollection<DocumentItem> Documents { get; set; }

        public DocumentType()
        {
            // required by EF
        }
    }
}
