namespace BackofficeClient.Models.Database;

public class PaymentUpd
{
    /// <summary>
    /// Платеж
    /// </summary>
    public long PaymentUpdId { get; set; }

    /// <summary>
    /// Позиция Спецификации
    /// </summary>
    public long? SpecPositionId { get; set; }

    /// <summary>
    /// Наименование УПД
    /// </summary>
    public string? PaymentUpdName { get; set; }

    /// <summary>
    /// Номер УПД
    /// </summary>
    public string? PaymentUpdNum { get; set; }

    /// <summary>
    /// Дата УПД
    /// </summary>
    public DateOnly? PaymentUpdDate { get; set; }

    /// <summary>
    /// Объем по УПД
    /// </summary>
    public decimal? PaymentUpdSum { get; set; }

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