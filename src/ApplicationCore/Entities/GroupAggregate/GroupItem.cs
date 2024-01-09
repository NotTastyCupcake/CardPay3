namespace Metcom.CardPay3.ApplicationCore.Entities.GroupAggregate
{
    public class GroupItem : BaseEntity
    {
        public int EmployerId { get; private set; }
        public GroupItem(int employerItemId)
        {
            EmployerId = employerItemId;
        }
        public GroupItem()
        {
            // required by EF
        }
    }
}
