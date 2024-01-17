namespace BackofficeClient.Models.Database;

public class SpecComment
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public long SpecCommentId { get; set; }

    /// <summary>
    /// Спецификации
    /// </summary>
    public long? SpecId { get; set; }

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

    public virtual Spec? Spec { get; set; }
}