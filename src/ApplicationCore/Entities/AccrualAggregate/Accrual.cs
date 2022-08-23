using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate
{
    public class Accrual : BaseEntity
    {
        public string OrganizationId { get; private set; }

        private List<AccrualItem> _items = new List<AccrualItem>();
        public IReadOnlyCollection<AccrualItem> Items => _items.AsReadOnly();

        public decimal TotalAmount => _items.Sum(i => i.Amount);

        public Accrual(string idOrganization)
        {
            OrganizationId = idOrganization;
        }

        public void AddItem(int personId, int payDay, decimal amount, int idTypePay, int idOperationType)
        {
            if (!Items.Any(i => i.PersonId == personId && i.IdPayType == idTypePay))
            {
                _items.Add(new AccrualItem(personId, payDay, amount, idTypePay, idOperationType));
                return;
            }
        }
        public void RemoveItem(int personId)
        {
            _items.RemoveAll(i => i.PersonId == personId);
        }

        public void SetNewBuyerId(string organizationId)
        {
            OrganizationId = organizationId;
        }
    }
}
