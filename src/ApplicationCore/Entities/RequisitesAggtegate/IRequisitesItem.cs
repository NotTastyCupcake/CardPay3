namespace Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate
{
    public interface IRequisitesItem
    {
        string AccountNumber { get; }
        int IdCardType { get; }
        int IdCurrency { get; }
        int IdDivision { get; }
        int INN { get; }
        string InsuranceNumber { get; }
        string LatinFirstName { get; }
        string LatinLastName { get; }
        int IdStatus { get; set; }
    }
}