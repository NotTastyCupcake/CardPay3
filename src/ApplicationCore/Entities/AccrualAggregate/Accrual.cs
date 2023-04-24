using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate
{
    /// <summary>
    /// Операция
    /// </summary>
    public class Accrual : BaseEntity
    {
        private List<AccrualItem> _items = new List<AccrualItem>();

        public IReadOnlyCollection<AccrualItem> Items => _items.AsReadOnly();

        #region Ссылки на объект
        public int IdOrganization { get; private set; }
        public Organization Organization { get; private set; }

        public int IdAccruaType { get; private set; }

        public int IdOperationType { get; private set; }
        public OperationType OperationType { get; set; }
        #endregion

        public int AccrualDay { get; private set; }

        public decimal TotalAmount => _items.Sum(i => i.Amount);


        public Accrual(int idOrganization, int accrualDay, int idAccrualType, int idOperationType)
        {
            IdOrganization = idOrganization;
            SetAccrualDay(accrualDay);
            IdAccruaType = idAccrualType;
            IdOperationType = idOperationType;
        }

        public Accrual()
        {
            // required by EF
        }

        public void AddItem(int employerId, decimal amount)
        {
            if (!Items.Any(i => i.IdEmployer == employerId))
            {
                _items.Add(new AccrualItem(employerId, amount));
                return;
            }
        }

        public void RemoveEmployer(int employerId)
        {
            _items.RemoveAll(i => i.IdEmployer == employerId);
        }

        public void SetNewOrganizationId(int organizationId)
        {
            Guard.Against.OutOfRange(organizationId, nameof(organizationId), 1, int.MaxValue);

            IdOrganization = organizationId;
        }

        public void SetAccrualDay(int accrualDay)
        {
            Guard.Against.OutOfRange(accrualDay, nameof(accrualDay), 1, 31);

            AccrualDay = accrualDay;
        }
    }
}
