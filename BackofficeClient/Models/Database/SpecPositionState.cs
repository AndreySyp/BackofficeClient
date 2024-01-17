namespace BackofficeClient.Models.Database;

public class SpecPositionState
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public long SpecPositionStateId { get; set; }

    /// <summary>
    /// Позиция Спецификации
    /// </summary>
    public long? SpecPositionId { get; set; }

    /// <summary>
    /// Статус
    /// </summary>
    public string? StateText { get; set; }

    /// <summary>
    /// Дата статуса
    /// </summary>
    public DateOnly? StateDate { get; set; }

    /// <summary>
    /// Комментарий
    /// </summary>
    public string? Comment { get; set; }

    /// <summary>
    /// Логин пользователя
    /// </summary>
    public string? UpdatedBy { get; set; }

    /// <summary>
    /// Дата и время последнего изменения
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    public virtual SpecPosition? SpecPosition { get; set; }
}