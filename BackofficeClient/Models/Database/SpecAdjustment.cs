namespace BackofficeClient.Models.Database;

public class SpecAdjustment
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public long SpecAdjustmentId { get; set; }

    /// <summary>
    /// Спецификации
    /// </summary>
    public long? SpecId { get; set; }

    /// <summary>
    /// Комментарий
    /// </summary>
    public string? AdjustmentText { get; set; }

    /// <summary>
    /// Дата
    /// </summary>
    public DateOnly? AdjustmentDate { get; set; }

    /// <summary>
    /// Логин пользователя
    /// </summary>
    public string? UpdatedBy { get; set; }

    /// <summary>
    /// Дата и время последнего изменения
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    public virtual Spec? Spec { get; set; }
}