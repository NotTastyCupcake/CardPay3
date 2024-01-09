namespace Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate
{
    public interface IRequisitesItem
    {
        string AccountNumber { get; }
        BankCardType CardType { get; }
        BankCurrency Currency { get; }
        BankDivision Division { get; }
        Employee Employee { get; }
        int? IdCardType { get; }
        int IdCurrency { get; }
        int IdDivision { get; }
        int? IdEmployer { get; }
        int INN { get; }
        string InsuranceNumber { get; }
        string LatinFirstName { get; }
        string LatinLastName { get; }
        Status Status { get; set; }
    }
}