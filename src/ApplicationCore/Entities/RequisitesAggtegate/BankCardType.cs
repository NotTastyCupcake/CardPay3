namespace Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate
{
    public class BankCardType : BaseEntity
    {
        public BankCardType(string nameType)
        {
            NameType = nameType;
        }
        public BankCardType()
        {

        }
        public string NameType { get; set; }
    }
}
