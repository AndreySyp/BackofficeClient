namespace BackofficeClient.Models.Database;

public class ContractState
{
    public long StateId { get; set; }

    public long ContractId { get; set; }

    public string StateName { get; set; } = null!;

    public DateOnly StateDate { get; set; }

    public string? StateComment { get; set; }

    public bool IsAutomaticInit { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual Contract Contract { get; set; } = null!;
}