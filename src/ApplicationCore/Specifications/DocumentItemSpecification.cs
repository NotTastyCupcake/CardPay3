using Ardalis.Specification;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Specifications
{
    public class DocumentItemSpecification : Specification<DocumentItem>, ISingleResultSpecification<DocumentItem>
    {
        public DocumentItemSpecification(int idDocument)
        {
            Query
                .Where(a => a.Id == idDocument);
        }

        public DocumentItemSpecification(string issuedBy, string subdivisionCode, int idType, DateTime dateIssued)
        {
            Query
                .Where(a => a.IssuedBy == issuedBy && a.SubdivisionCode == subdivisionCode && a.IdType == idType && a.DataIssued.Date == dateIssued.Date);
        }
    }
}
