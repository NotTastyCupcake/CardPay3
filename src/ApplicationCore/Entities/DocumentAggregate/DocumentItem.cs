using System;

namespace Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate
{
    /// <summary>
    /// Документ, удостоверяющий личность
    /// </summary>
    public class DocumentItem : BaseEntity
    {

        public string FullName => $"{Type?.Name ?? "<Нет типа>"}: {SubdivisionCode}";

        /// <summary>
        /// Вид документа, удостоверяющего личность.
        /// </summary>
        public virtual DocumentType Type { get; private set; }
        public int IdType { get; private set; }

        /// <summary>
        /// Серия
        /// </summary>
        public string Series { get; private set; }
        /// <summary>
        /// Номер
        /// </summary>
        public string Number { get; private set; }
        /// <summary>
        /// Дата выдачи
        /// </summary>
        public DateTime DataIssued { get; private set; }
        /// <summary>
        /// Кем выдан
        /// </summary>
        public string IssuedBy { get; private set; }
        /// <summary>
        /// Код подразделения
        /// </summary>
        public string SubdivisionCode { get; private set; }

        public DocumentItem(int idType, 
                            string series, 
                            string number, 
                            DateTime dataIssued, 
                            string issuedBy,
                            string subdivisionCode)
        {
            IdType = idType;
            Series = series;
            Number = number;
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
