using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate
{
    /// <summary>
    /// Операция
    /// </summary>
    public class Accrual : BaseEntity
    {
        private readonly List<AccrualItem> _items = new List<AccrualItem>();

        public virtual IReadOnlyCollection<AccrualItem> Items => _items.AsReadOnly();

        #region Ссылки на объект
        public int IdOrganization { get; private set; }
        public virtual Organization Organization { get; private set; }

        public int IdAccruaType { get; private set; }

        public int IdOperationType { get; private set; }
        public virtual OperationType OperationType { get; set; }
        #endregion

        public DateTime AccrualDay { get; private set; }

        public decimal TotalAmount => _items.Sum(i => i.Amount);


        public Accrual(int idOrganization, DateTime accrualDay, int idAccrualType, int idOperationType)
        {
            IdOrganization = idOrganization;
            AccrualDay = accrualDay;
            IdAccruaType = idAccrualType;
            IdOperationType = idOperationType;
        }

        public Accrual()
        {
            // required by EF
        }

        public void AddItem(int employerId, decimal amount)
        {
            if (!Items.Any(i => i.IdEmployee == employerId))
            {
                _items.Add(new AccrualItem(employerId, amount));
                return;
            }
        }

        public void RemoveEmployer(int employerId)
        {
            _items.RemoveAll(i => i.IdEmployee == employerId);
        }

        public void SetNewOrganizationId(int organizationId)
        {
            Guard.Against.OutOfRange(organizationId, nameof(organizationId), 1, int.MaxValue);

            IdOrganization = organizationId;
        }
    }
}
