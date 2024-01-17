namespace BackofficeClient.Models.Database;

public class SupChangeAction
{
    public long SupChangeActionId { get; set; }

    public long? SupplyPositionId { get; set; }

    public string? SupColumnName { get; set; }

    public string? UserLogin { get; set; }

    public string? ValueOld { get; set; }

    public string? ValueNew { get; set; }

    public string? SupChangeActionComment { get; set; }

    public bool IsRolledBack { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }

    public virtual SupColumn? SupColumnNameNavigation { get; set; }

    public virtual SupplyPosition? SupplyPosition { get; set; }

    public virtual Person? UserLoginNavigation { get; set; }
}