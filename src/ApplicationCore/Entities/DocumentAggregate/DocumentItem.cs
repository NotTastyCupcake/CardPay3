using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate
{
    public class DocumentItem : BaseEntity
    {
        public DocumentType Type { get; private set; }
        public int IdType { get; private set; }

        public DateTime DataIssued { get; private set; }
        public string IssuedBy { get; private set; }
        public string SubdivisionCode { get; private set; }

        public DocumentItem(int id ,int idType ,DateTime dataIssued, string issuedBy, string subdivisionCode)
        {
            Id = id;
            IdType = idType;
            DataIssued = dataIssued;
            IssuedBy = issuedBy;
            SubdivisionCode = subdivisionCode;
        }
    }
}
