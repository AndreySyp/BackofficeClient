using System.ComponentModel.DataAnnotations.Schema;

namespace BackofficeClient.Models.Database.Views;

public partial class VPosition
{
    public string? PositionId { get; set; }

    public string? RequestNum { get; set; }

    public DateOnly? RequestDate { get; set; }

    public string? PositionNum { get; set; }

    public string? MtrName { get; set; }

    public string? GroupMtr { get; set; }

    public string? DocNtd { get; set; }

    public decimal? Amount { get; set; }

    public string? Measure { get; set; }

    public string? DeliveryTime { get; set; }

    public string? Basis { get; set; }

    public string? Condition { get; set; }

    public string? Nmck { get; set; }

    public string? Currency { get; set; }

    public string? ProcedureGpb { get; set; }

    public string? ProcedureGpb4 { get; set; }

    public string? SupState { get; set; }

    public string? Person { get; set; }

    public string? DateCustomerQuery { get; set; }

    public string? DateDocs { get; set; }

    public string? DateAgreement { get; set; }

    public string? DateAs { get; set; }

    public string? SupName { get; set; }

    public string? Timing { get; set; }

    public int? TimingMax { get; set; }

    public decimal? IncPrice { get; set; }

    public decimal? IncPriceNds { get; set; }

    public string? Manufacturer { get; set; }

    public decimal? IncPriceCur { get; set; }

    public decimal? IncPriceCurNds { get; set; }

    public decimal? ExchangeRate { get; set; }

    public decimal? OutPrice { get; set; }

    public decimal? OutPriceNds { get; set; }

    public decimal? OutPriceCur { get; set; }

    public decimal? OutPriceCurNds { get; set; }
}