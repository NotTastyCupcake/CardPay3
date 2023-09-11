using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate
{
    public class DocumentItem : BaseEntity
    {

        public string FullName => $"{Type.DocumentName}: {SubdivisionCode}";

        public virtual DocumentType Type { get; private set; }
        public int IdType { get; private set; }

        public DateTime DataIssued { get; private set; }
        public string IssuedBy { get; private set; }
        public string SubdivisionCode { get; private set; }

        public DocumentItem(int idType ,DateTime dataIssued, string issuedBy, string subdivisionCode)
        {
            IdType = idType;
            DataIssued = dataIssued;
            IssuedBy = issuedBy;
            SubdivisionCode = subdivisionCode;
        }
        public DocumentItem()
        {
            // required by EF
        }
    }
}
