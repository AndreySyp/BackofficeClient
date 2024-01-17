namespace BackofficeClient.Models.Database;

public class Procedure
{
    public long ProcedureId { get; set; }

    public string ProcedureGpb { get; set; } = null!;

    public string? ProcedureGpb4 { get; set; }

    public long? SupStateId { get; set; }

    public string? SupState { get; set; }

    public DateOnly? ProcedureDateEnd { get; set; }

    public string? Suppliers { get; set; }

    public string? Members { get; set; }

    public Guid? ProcedureUuid { get; set; }

    public string? ProcedureComment { get; set; }

    public DateTime? UpdateOnRegistry { get; set; }

    public DateTime? UpdateOnData { get; set; }

    public DateTime? UpdateOnReport2022 { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? ProcedureName { get; set; }

    /// <summary>
    /// Дата публикации
    /// </summary>
    public DateOnly? ProcedureDateBeg { get; set; }

    public bool? IsAutomaticInit { get; set; }

    /// <summary>
    /// Ссылка на последнее загруженное ТКП
    /// </summary>
    public string? LastTkpLink { get; set; }

    /// <summary>
    /// Обновлена Процедура
    /// </summary>
    public string UpdatedBy { get; set; } = null!;

    /// <summary>
    /// Оценочная стоимость лота
    /// </summary>
    public decimal? AssessedValue { get; set; }

    public virtual ICollection<Bidder> Bidders { get; set; } = new List<Bidder>();

    public virtual ICollection<Deal> Deals { get; set; } = new List<Deal>();

    public virtual ICollection<Position> Positions { get; set; } = new List<Position>();

    public virtual ICollection<ProcedureComment> ProcedureComments { get; set; } = new List<ProcedureComment>();

    public virtual ICollection<Spec> Specs { get; set; } = new List<Spec>();
}