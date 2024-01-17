namespace BackofficeClient.Models.Database;

public class SpecPosition
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public long SpecPositionId { get; set; }

    /// <summary>
    /// Спецификация
    /// </summary>
    public long SpecId { get; set; }

    /// <summary>
    /// Множественная связь с поставщиками
    /// </summary>
    public long? SpecSupplierId { get; set; }

    /// <summary>
    /// Поставщик
    /// </summary>
    public string? SupName { get; set; }

    public string? ContractSup { get; set; }

    /// <summary>
    /// Поставщик
    /// </summary>
    public long? SupplierId { get; set; }

    public long? PositionId { get; set; }

    public string? RequestNum { get; set; }

    public string? ProcedureGpb { get; set; }

    /// <summary>
    /// Наименование МТР
    /// </summary>
    public string? MtrName { get; set; }

    /// <summary>
    /// Единица измерения
    /// </summary>
    public string? Measure { get; set; }

    /// <summary>
    /// Количество
    /// </summary>
    public decimal? Amount { get; set; }

    /// <summary>
    /// Стоимость (клиент)
    /// </summary>
    public decimal? PriceCustomer { get; set; }

    /// <summary>
    /// Стоимость (поставщик)
    /// </summary>
    public decimal? PriceSup { get; set; }

    /// <summary>
    /// Цена (клиент)
    /// </summary>
    public decimal? PriceUnitCustomer { get; set; }

    /// <summary>
    /// Цена (поставщик)
    /// </summary>
    public decimal? PriceUnitSup { get; set; }

    /// <summary>
    /// Стоимость с НДС (клиент)
    /// </summary>
    public decimal? PriceCustomerNds { get; set; }

    /// <summary>
    /// Стоимость с НДС (поставщик)
    /// </summary>
    public decimal? PriceSupNds { get; set; }

    /// <summary>
    /// Статус cпецификации
    /// </summary>
    public string? SpecState { get; set; }

    /// <summary>
    /// Статус (с комментарием)
    /// </summary>
    public string? SpecStateFull { get; set; }

    /// <summary>
    /// Дата поставки по договору
    /// </summary>
    public DateOnly? PosSupDate { get; set; }

    /// <summary>
    /// Срок поставки по договору
    /// </summary>
    public int? PosTermDate { get; set; }

    /// <summary>
    /// Ответственный
    /// </summary>
    public string? Person { get; set; }

    /// <summary>
    /// Входящее УПД
    /// </summary>
    public string? IncomeUpd { get; set; }

    public string? PositionNum { get; set; }

    /// <summary>
    /// Нормативный документ
    /// </summary>
    public string? DocNtd { get; set; }

    /// <summary>
    /// Изготовитель
    /// </summary>
    public string? Manufacturer { get; set; }

    /// <summary>
    /// Базис
    /// </summary>
    public string? Basis { get; set; }

    /// <summary>
    /// Срок поставки
    /// </summary>
    public string? Timing { get; set; }

    /// <summary>
    /// Максимальный срок поставки
    /// </summary>
    public string? TimingMax { get; set; }

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

    public virtual ICollection<PaymentUpd> PaymentUpds { get; set; } = new List<PaymentUpd>();

    public virtual Position? Position { get; set; }

    public virtual Spec Spec { get; set; } = null!;

    public virtual ICollection<SpecPositionComment> SpecPositionComments { get; set; } = new List<SpecPositionComment>();

    public virtual ICollection<SpecPositionState> SpecPositionStates { get; set; } = new List<SpecPositionState>();

    public virtual SpecSupplier? SpecSupplier { get; set; }
}