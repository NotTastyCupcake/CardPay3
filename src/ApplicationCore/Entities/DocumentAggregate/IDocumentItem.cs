using System;
using System.Collections.Generic;
using System.Text;

namespace Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate
{
    public interface IDocumentItem
    {
        public int IdType { get; }
        public string Series { get; }
        public string Number { get; }
        public DateTime DataIssued { get; }
        public string IssuedBy { get; }
        public string SubdivisionCode { get; }
    }
}
