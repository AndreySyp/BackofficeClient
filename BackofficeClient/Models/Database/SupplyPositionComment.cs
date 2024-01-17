namespace BackofficeClient.Models.Database;

public class SupplyPositionComment
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public long SupplyPositionCommentId { get; set; }

    /// <summary>
    /// Позиция Спецификации
    /// </summary>
    public long? SupplyPositionId { get; set; }

    /// <summary>
    /// Комментарий
    /// </summary>
    public string? CommentText { get; set; }

    /// <summary>
    /// Дата комментария
    /// </summary>
    public DateOnly? CommentDate { get; set; }

    /// <summary>
    /// Логин пользователя
    /// </summary>
    public string? UpdatedBy { get; set; }

    /// <summary>
    /// Дата и время последнего изменения
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    public long? PositionId { get; set; }

    public virtual SupplyPosition? SupplyPosition { get; set; }
}