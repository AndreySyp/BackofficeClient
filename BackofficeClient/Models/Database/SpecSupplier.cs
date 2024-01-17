namespace BackofficeClient.Models.Database;

public class SpecSupplier
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public long SpecSupplierId { get; set; }

    /// <summary>
    /// Спецификация
    /// </summary>
    public long? SpecId { get; set; }

    /// <summary>
    /// Поставщик
    /// </summary>
    public string? SupName { get; set; }

    public long? SupplierId { get; set; }

    /// <summary>
    /// Договор
    /// </summary>
    public string? ContractName { get; set; }

    /// <summary>
    /// Договор
    /// </summary>
    public long? ContractId { get; set; }

    /// <summary>
    /// Наименование спецификации с Поставщиком
    /// </summary>
    public string? SpecNameSup { get; set; }

    /// <summary>
    /// Номер спецификации с Поставщиком
    /// </summary>
    public string? SpecNumSup { get; set; }

    /// <summary>
    /// Дата спецификации с Поставщиком
    /// </summary>
    public string? SpecDateSup { get; set; }

    /// <summary>
    /// Процент наценки
    /// </summary>
    public decimal? MarginPercent { get; set; }

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

    public virtual Spec? Spec { get; set; }

    public virtual ICollection<SpecPosition> SpecPositions { get; set; } = new List<SpecPosition>();
}