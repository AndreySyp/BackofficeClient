namespace BackofficeClient.Models.Database;

public class SupplyPosition
{
    public long SupplyPositionId { get; set; }

    public long? RequestId { get; set; }

    public int? Period { get; set; }

    public string? RequestNum { get; set; }

    public long? ProcedureId { get; set; }

    public string? ProcedureGpb { get; set; }

    public long? PositionId { get; set; }

    public string? GroupMtr { get; set; }

    public long? SpecId { get; set; }

    public string Segmentation { get; set; } = null!;

    public long? CustomerId { get; set; }

    public string? Customer { get; set; }

    public string? CustomerSpecNum { get; set; }

    public DateOnly? CustomerSpecDate { get; set; }

    public long? ContractIdCustomer { get; set; }

    public string? CustomerContract { get; set; }

    public long? SupplierId { get; set; }

    public string? SupName { get; set; }

    public string? SupplierSpecNum { get; set; }

    public DateOnly? SupplierSpecDate { get; set; }

    public long? ContractIdSupplier { get; set; }

    public string? SupplierContract { get; set; }

    public DateOnly? SupDate { get; set; }

    public int? TimingMax { get; set; }

    public string? MtrName { get; set; }

    public string? Measure { get; set; }

    public decimal? Amount { get; set; }

    public decimal? SupplierPriceUnit { get; set; }

    public decimal? SupplierPriceNds { get; set; }

    public DateOnly? ShippingDate { get; set; }

    public DateOnly? ShippingDateFact { get; set; }

    public decimal? CustomerPrice { get; set; }

    public string PersonForwarder { get; set; } = null!;

    public string? IncUpdNum { get; set; }

    public DateOnly? IncUpdDate { get; set; }

    public string? SupComment { get; set; }

    public string? SupState { get; set; }

    public string? SupObject { get; set; }

    public long? DealId { get; set; }

    public bool? IsImportInit { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Комментарий из Списка
    /// </summary>
    public string? SupCommentAdd { get; set; }

    /// <summary>
    /// Ответственный по Направлению
    /// </summary>
    public decimal? CustomerPriceUpd { get; set; }

    /// <summary>
    /// Направление ЦЗС, по которому происходит закупка/поставка
    /// </summary>
    public string PersonManager { get; set; } = null!;

    /// <summary>
    /// Файл из которого произведена загрузка
    /// </summary>
    public string? FileOrigin { get; set; }

    /// <summary>
    /// Отдел ведущий данные поставки
    /// </summary>
    public string? DepartmentOrigin { get; set; }

    /// <summary>
    /// Загружено пользователем из файла
    /// </summary>
    public bool? IsUserImport { get; set; }

    /// <summary>
    /// Дата и время создания записи
    /// </summary>
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Дата подписания с двух сторон
    /// </summary>
    public DateOnly? DateSignAll { get; set; }

    /// <summary>
    /// Валюта
    /// </summary>
    public string? Currency { get; set; }

    /// <summary>
    /// Обменный курс к рублю
    /// </summary>
    public decimal? ExchangeRate { get; set; }

    /// <summary>
    /// Цена Поставщик, Валюта
    /// </summary>
    public decimal? SupplierPriceUnitCur { get; set; }

    /// <summary>
    /// Стоимость Поставщик с НДС, Валюта
    /// </summary>
    public decimal? SupplierPriceNdsCur { get; set; }

    /// <summary>
    /// Стоимость Заказчик с НДС, Валюта
    /// </summary>
    public decimal? CustomerPriceCur { get; set; }

    /// <summary>
    /// Стоимость по УПД, Валюта
    /// </summary>
    public decimal? CustomerPriceUpdCur { get; set; }

    /// <summary>
    /// Дата подписания Поставщиком
    /// </summary>
    public DateOnly? DateSignSup { get; set; }

    /// <summary>
    /// Дата подписания Заказчиком
    /// </summary>
    public DateOnly? DateSignCustomer { get; set; }

    /// <summary>
    /// Конечный заказчик
    /// </summary>
    public string? CustomerEnd { get; set; }

    /// <summary>
    /// Дата оплаты аванса
    /// </summary>
    public DateOnly? AdvancePaymentDate { get; set; }

    /// <summary>
    /// Пользователь, создавший запись по Поставке
    /// </summary>
    public string CreatedBy { get; set; } = null!;

    public long? GroupMtrId { get; set; }

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
    /// Уникальный идентификатор записи
    /// </summary>
    public Guid SupplyPositionUuid { get; set; }

    public virtual ICollection<DeliverySchedule> DeliverySchedules { get; set; } = new List<DeliverySchedule>();

    public virtual ICollection<SupChangeAction> SupChangeActions { get; set; } = new List<SupChangeAction>();

    public virtual ICollection<SupplyPositionComment> SupplyPositionComments { get; set; } = new List<SupplyPositionComment>();

    public virtual TradeSign TradeSignNavigation { get; set; } = null!;
}