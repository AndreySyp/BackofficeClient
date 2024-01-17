namespace BackofficeClient.Models.Database;

public class RequestComment
{
    public long RequestCommentId { get; set; }

    public long RequestId { get; set; }

    public long? SupStateId { get; set; }

    public string? LoginText { get; set; }

    public string? PersonFullname { get; set; }

    public string? CommentText { get; set; }

    public DateOnly? CommentDate { get; set; }

    public bool IsActual { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual Request Request { get; set; } = null!;

    public virtual SupState? SupState { get; set; }
}