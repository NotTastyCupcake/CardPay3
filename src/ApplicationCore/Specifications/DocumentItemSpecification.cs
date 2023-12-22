using Ardalis.Specification;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using System;
using System.Linq;

namespace Metcom.CardPay3.ApplicationCore.Specifications
{
    public class DocumentItemSpecification : Specification<DocumentItem>, ISingleResultSpecification<DocumentItem>
    {
        public DocumentItemSpecification(string series, string number, int idType, DateTime dateIssued)
        {
            Query
                .Where(a => a.Series == series && a.Number == number && a.IdType == idType && a.DataIssued.Date == dateIssued.Date);
        }
    }
}
