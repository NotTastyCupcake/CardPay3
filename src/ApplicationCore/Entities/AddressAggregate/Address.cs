namespace Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate
{
    public class Address : BaseEntity
    {
        public int PersonId { get; set; }

        public int IdActualAddress { get; set; }
        public BaseAddress ActualAddress { get; set; }

        public int IdResidenceAddress { get; set; }
        public BaseAddress ResidenceAddress { get; set; }

        public int IdMailAddress { get; set; }
        public BaseAddress MailAddress { get; set; }

        public Address()
        {
            // required by EF
        }

        public Address(int personId)
        {
            PersonId = personId;
        }
        
    }
}
