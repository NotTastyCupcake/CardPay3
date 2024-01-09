using System.Collections.Generic;

namespace Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate
{
    public class DocumentType : BaseEntity
    {
        public string Name { get; private set; }
        /// <summary>
        /// Код вида документа
        /// </summary>
        public int Code { get; private set; }

        public DocumentType(string name , int code)
        {
            Name = name;
            Code = code;
        }

        public virtual ICollection<DocumentItem> Documents { get; set; }

        public DocumentType()
        {
            // required by EF
        }
    }
}
