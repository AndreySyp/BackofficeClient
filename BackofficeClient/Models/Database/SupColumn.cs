namespace BackofficeClient.Models.Database;

public class SupColumn
{
    public long SupColumnId { get; set; }

    public string SupColumnName { get; set; } = null!;

    /// <summary>
    /// Наименование для отображения на форме
    /// </summary>
    public string? SupColumnNote { get; set; }

    public string? SupColumnDesc { get; set; }

    public bool IsVisibleDefault { get; set; }

    public string? SupColumnType { get; set; }

    public virtual ICollection<SupChangeAction> SupChangeActions { get; set; } = new List<SupChangeAction>();

    public virtual ICollection<SupColumnUser> SupColumnUsers { get; set; } = new List<SupColumnUser>();
}