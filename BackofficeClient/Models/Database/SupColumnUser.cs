namespace BackofficeClient.Models.Database;

public class SupColumnUser
{
    public long SupColumnUserId { get; set; }

    public string? SupColumnName { get; set; }

    public string? UserLogin { get; set; }

    public string? SupColumnUserComment { get; set; }

    /// <summary>
    /// Наличие ORDER BY: true - asc, false - desc, null - отсутствие сортировки
    /// </summary>
    public bool? Sorting { get; set; }

    public bool IsVisible { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public virtual SupColumn? SupColumnNameNavigation { get; set; }

    public virtual Person? UserLoginNavigation { get; set; }
}