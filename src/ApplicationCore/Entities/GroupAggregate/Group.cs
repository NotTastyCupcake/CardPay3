using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;

namespace Metcom.CardPay3.ApplicationCore.Entities.GroupAggregate
{
    public class Group : BaseEntity
    {
        public int IdOrganization { get; private set; }

        private readonly List<GroupItem> _items = new List<GroupItem>();
        public virtual IReadOnlyCollection<GroupItem> Items => _items.AsReadOnly();
        public string Name { get; private set; }
        public int Quantity => _items.Count;

        public virtual Organization Organization { get; private set; }

        public Group(int organizationId, string nameGroup)
        {
            IdOrganization = organizationId;
            Name = nameGroup;
        }

        public Group()
        {
            // required by EF
        }

        public void AddItem(int employerItemId)
        {
            if(!Items.Any(i => i.EmployerId == employerItemId))
            {
                _items.Add(new GroupItem(employerItemId));
                return;
            }
        }

        public void DeleteItem(int employerItemId)
        {
            var existingItem = Items.FirstOrDefault(i => i.EmployerId == employerItemId);
            _items.Remove(existingItem);
        }

        public void UpdateNameGroup(string newNameGroup)
        {
            Guard.Against.NullOrEmpty(newNameGroup, nameof(newNameGroup));

            Name = newNameGroup;
        }
    }
}
