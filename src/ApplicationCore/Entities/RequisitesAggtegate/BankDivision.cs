namespace Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate
{
    public class BankDivision : BaseEntity
    {
        public BankDivision()
        {

        }

        public BankDivision(string divisionName)
        {
            DivisionName = divisionName;
        }

        public string DivisionName { get; private set; }
    }
}
