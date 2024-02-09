namespace BackofficeClient.Models.Database.Views;

public class VProcedure
{
    public long? Id { get; set; }

    public string? ProcedureGpb { get; set; }

    public string? ProcedureGpb4 { get; set; }

    public string? RequestNum { get; set; }

    public string? ProcedureName { get; set; }

    public string? SupState { get; set; }

    public long? Nr { get; set; }

    public long? Np { get; set; }

    public string? Members { get; set; }

    public string? SupName { get; set; }

    public DateOnly? ProcedureDateEnd { get; set; }

    public string? ProcedureComment { get; set; }

    public string? Person { get; set; }

    public decimal? SumIncPrice { get; set; }

    public decimal? SumIncPriceNds { get; set; }

    public DateOnly? ProcedureDateBeg { get; set; }

    public string? DealDate { get; set; }

    public string? LastTkpLink { get; set; }

    public string? GroupMtr { get; set; }
}
