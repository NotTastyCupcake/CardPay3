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
        public IReadOnlyCollection<GroupItem> Items => _items.AsReadOnly();
        public string Name { get; private set; }
        public int Quantity => _items.Count;

        public PersonOrganization Organization { get; private set; }

        public Group(int organizationId, string nameGroup)
        {
            IdOrganization = organizationId;
            Name = nameGroup;
        }

        public Group()
        {
            // required by EF
        }

        public void AddItem(int personItemId)
        {
            if(!Items.Any(i => i.PersonId == personItemId))
            {
                _items.Add(new GroupItem(personItemId));
                return;
            }
        }

        public void DeleteItem(int personItemId)
        {
            var existingItem = Items.FirstOrDefault(i => i.PersonId == personItemId);
            _items.Remove(existingItem);
        }

        public void UpdateNameGroup(string newNameGroup)
        {
            Guard.Against.NullOrEmpty(newNameGroup, nameof(newNameGroup));

            Name = newNameGroup;
        }
    }
}
