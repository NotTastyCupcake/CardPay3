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

        public string OrganizationId { get; private set; }
        public int AccrualDay { get; private set; }
        public int IdType { get; private set; }
        public int IdOperationType { get; private set; }

        public decimal TotalAmount => _items.Sum(i => i.Amount);

        public Accrual(string idOrganization, int accrualDay, int idAccrualType, int idOperationType)
        {
            OrganizationId = idOrganization;
            SetAccrualDay(accrualDay);
            IdType = idAccrualType;
            IdOperationType = idOperationType;
        }

        public void AddItem(int personId, decimal amount)
        {
            if (!Items.Any(i => i.PersonId == personId))
            {
                _items.Add(new AccrualItem(personId, amount));
                return;
            }
        }

        public void RemovePerson(int personId)
        {
            _items.RemoveAll(i => i.PersonId == personId);
        }

        public void SetNewOrganizationId(string organizationId)
        {
            Guard.Against.NullOrWhiteSpace(organizationId, nameof(organizationId));

            OrganizationId = organizationId;
        }

        public void SetAccrualDay(int accrualDay)
        {
            Guard.Against.OutOfRange(accrualDay, nameof(accrualDay), 1, 31);

            AccrualDay = accrualDay;
        }
    }
}
