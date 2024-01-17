namespace BackofficeClient.Models.Database;

public partial class SqlLog
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public long SqlLogId { get; set; }

    /// <summary>
    /// Текст
    /// </summary>
    public string? SqlText { get; set; }

    public string? UserLogin { get; set; }

    /// <summary>
    /// Изменяемая таблица, в случае если она - единственная
    /// </summary>
    public string? TableName { get; set; }

    /// <summary>
    /// Изменяемый параметр, в случае если он - единственный
    /// </summary>
    public string? ColumnName { get; set; }

    /// <summary>
    /// Метод
    /// </summary>
    public string? Method { get; set; }

    /// <summary>
    /// Признак выполнения
    /// </summary>
    public bool IsExecuted { get; set; }

    /// <summary>
    /// Логин
    /// </summary>
    public string UpdatedBy { get; set; } = null!;

    /// <summary>
    /// Время обработки записи
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    public virtual Person? UserLoginNavigation { get; set; }
}