using System;

namespace Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate
{
    /// <summary>
    /// Документ, удостоверяющий личность
    /// </summary>
    public class DocumentItem : BaseEntity
    {

        public string FullName => $"{Series} {Number}";

        /// <summary>
        /// Вид документа, удостоверяющего личность.
        /// </summary>
        public virtual DocumentType Type { get; set; }
        public int IdType { get; set; }

        /// <summary>
        /// Серия
        /// </summary>
        public string Series { get; set; }
        /// <summary>
        /// Номер
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// Дата выдачи
        /// </summary>
        public DateTime DataIssued { get; set; }
        /// <summary>
        /// Кем выдан
        /// </summary>
        public string IssuedBy { get; set; }
        /// <summary>
        /// Код подразделения
        /// </summary>
        public string SubdivisionCode { get; set; }
    }
}
