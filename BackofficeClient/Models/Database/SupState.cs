namespace BackofficeClient.Models.Database;

public class SupState
{
    public long SupStateId { get; set; }

    public long PositionId { get; set; }

    public string SupStateName { get; set; } = null!;

    public DateOnly? SupStateDate { get; set; }

    public string? ProcedureGpb { get; set; }

    public string? RequestNum { get; set; }

    public string? PositionNum { get; set; }

    public string? MtrName { get; set; }

    public bool IsAutomaticInit { get; set; }

    public DateTime? UpdateOnReport2022 { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual Position Position { get; set; } = null!;

    public virtual ICollection<ProcedureComment> ProcedureComments { get; set; } = new List<ProcedureComment>();

    public virtual ICollection<RequestComment> RequestComments { get; set; } = new List<RequestComment>();
}