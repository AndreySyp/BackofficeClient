namespace BackofficeClient.Models.Database;

public class Request
{
    /// <summary>
    /// Заявка
    /// </summary>
    public long RequestId { get; set; }

    /// <summary>
    /// № заявки (B2-DATA, A1-REG, request_num-r22)
    /// </summary>
    public string? RequestNum { get; set; }

    /// <summary>
    /// Дата создания заявки (K11-DATA, E5-REG, request_date-r22)
    /// </summary>
    public DateOnly? RequestDate { get; set; }

    /// <summary>
    /// Статус заявки (процессор) (I9-DATA, B2-REG, request_state-r22) 
    /// </summary>
    public string? RequestState { get; set; }

    /// <summary>
    /// Наименование заявки (C3-DATA, C3-REG, request_name-r22)
    /// </summary>
    public string? RequestName { get; set; }

    /// <summary>
    /// Контрагент (D4-DATA, D4-REG, customer-r22)
    /// </summary>
    public string? Customer { get; set; }

    /// <summary>
    /// ID заказчика (E5-DATA)
    /// </summary>
    public Guid? CustomerUuid { get; set; }

    /// <summary>
    /// ID заявки (A1-DATA)
    /// </summary>
    public Guid? RequestUuid { get; set; }

    /// <summary>
    /// Комментарий (процессор) (G7-DATA)
    /// </summary>
    public string? RequestCommentProcessor { get; set; }

    public long? SupStateId { get; set; }

    public string? SupState { get; set; }

    public string? RequestComment { get; set; }

    public string? Priority { get; set; }

    /// <summary>
    /// Время обновления из файла с рег. выгрузкой (процессор)
    /// </summary>
    public DateTime? UpdateOnRegistry { get; set; }

    /// <summary>
    /// Время обновления из файла с общей датой (процессор)
    /// </summary>
    public DateTime? UpdateOnData { get; set; }

    /// <summary>
    /// Время обновления из таблицы Отчет2022
    /// </summary>
    public DateTime? UpdateOnReport2022 { get; set; }

    /// <summary>
    /// Время обновления
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Пользователь, который внес изменения
    /// </summary>
    public string? UpdatedBy { get; set; }

    /// <summary>
    /// Заказчик
    /// </summary>
    public long? CustomerId { get; set; }

    public bool? IsAutomaticInit { get; set; }

    public string? PersonManager { get; set; }

    /// <summary>
    /// Время обновления
    /// </summary>
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Пользователь, который внес изменения
    /// </summary>
    public string? CreatedBy { get; set; }

    /// <summary>
    /// Признак сделки (АЗ/ТТ/ТК)
    /// АЗ – аутсорсинг закупок
    /// ТТ – товарный трейдинг
    /// ТК – товарный кредит
    /// 
    /// </summary>
    public string TradeSign { get; set; } = null!;

    /// <summary>
    /// Признак закупки продукции &quot;На склад&quot;
    /// (не должно отмечаться в Прогнозе Выручки)
    /// </summary>
    public bool ToWarehouse { get; set; }

    /// <summary>
    /// Признак интеграции с ПК &quot;Резерв&quot;
    /// </summary>
    public bool ToReserve { get; set; }
    public virtual ICollection<Position> Positions { get; set; } = new List<Position>();

    public virtual ICollection<RequestComment> RequestComments { get; set; } = new List<RequestComment>();

    public virtual ICollection<Spec> Specs { get; set; } = new List<Spec>();

    public virtual TradeSign TradeSignNavigation { get; set; } = null!;
}