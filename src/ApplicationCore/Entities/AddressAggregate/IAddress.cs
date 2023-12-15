namespace Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate
{
    public interface IAddress
    {
        Geographic City { get; }
        Geographic Country { get; }
        string District { get; }
        Employee Employee { get; }
        string FullName { get; }
        int IdCity { get; }
        int IdCountry { get; }
        int? IdEmployee { get; }
        int IdLocality { get; }
        int IdState { get; }
        int IdStreet { get; }
        Geographic Locality { get; }
        int NumApartment { get; }
        int NumCase { get; }
        int NumHome { get; }
        int Postcode { get; }
        Geographic State { get; }
        Geographic Street { get; }
        string StreetType { get; }
    }
}