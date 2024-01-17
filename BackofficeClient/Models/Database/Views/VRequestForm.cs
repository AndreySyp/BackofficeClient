namespace BackofficeClient.Models.Database.Views;

public class VRequestForm
{
    /// <summary>
    /// ID
    /// </summary>
    public long? RequestId { get; set; }

    /// <summary>
    /// Номер заявки
    /// </summary>
    public string? RequestNum { get; set; }

    /// <summary>
    /// Дата создания заявки
    /// </summary>
    public DateOnly? RequestDate { get; set; }

    /// <summary>
    /// Наименование заявки
    /// </summary>
    public string? RequestName { get; set; }

    /// <summary>
    /// Контрагент
    /// </summary>
    public string? Customer { get; set; }

    /// <summary>
    /// Сегментация клиента
    /// </summary>
    public string? NameShort { get; set; }

    /// <summary>
    /// Группа МТР
    /// </summary>
    public string? GroupMtr { get; set; }

    /// <summary>
    /// Статус заявки
    /// </summary>
    public string? SupState { get; set; }

    /// <summary>
    /// Количество позиций
    /// </summary>
    public long? Np { get; set; }

    /// <summary>
    /// Количество лотов
    /// </summary>
    public long? Nl { get; set; }

    /// <summary>
    /// Комментарий
    /// </summary>
    public string? RequestComment { get; set; }

    /// <summary>
    /// Приоритет
    /// </summary>
    public string? Priority { get; set; }

    /// <summary>
    /// Вх. стоимость; руб. без НДС.
    /// </summary>
    public decimal? SumIncPrice { get; set; }

    public string? PersonManager { get; set; }
}