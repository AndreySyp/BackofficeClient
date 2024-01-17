namespace BackofficeClient.Models.Database;

public class Deal
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public long DealId { get; set; }

    /// <summary>
    /// Наименование сделки Документооборот
    /// </summary>
    public string? DealName { get; set; }

    /// <summary>
    /// Номер заявки Документооборот
    /// </summary>
    public string? DocRequestNum { get; set; }

    /// <summary>
    /// Регистрационный номер
    /// </summary>
    public string? DocNum { get; set; }

    /// <summary>
    /// Дата
    /// </summary>
    public DateOnly DocDate { get; set; }

    /// <summary>
    /// Номер из файла
    /// </summary>
    public string? FileNum { get; set; }

    /// <summary>
    /// Номер заявки
    /// </summary>
    public string? StrRequestNum { get; set; }

    /// <summary>
    /// Процедура ГПБ
    /// </summary>
    public long ProcedureId { get; set; }

    /// <summary>
    /// Номер лота
    /// </summary>
    public string? ProcedureGpb { get; set; }

    /// <summary>
    /// Номенклатура - группа МТР
    /// </summary>
    public string? GroupMtr { get; set; }

    /// <summary>
    /// Схема
    /// </summary>
    public string? Scheme { get; set; }

    /// <summary>
    /// Заказчик
    /// </summary>
    public long? CustomerId { get; set; }

    /// <summary>
    /// Заказчик
    /// </summary>
    public string? Customer { get; set; }

    /// <summary>
    /// Заказчик - Документ
    /// </summary>
    public string? CustomerDoc { get; set; }

    /// <summary>
    /// Заказчик - Дата
    /// </summary>
    public string? CustomerDateType { get; set; }

    /// <summary>
    /// Заказчик - Количество дней
    /// </summary>
    public int? CustomerDaysAmount { get; set; }

    /// <summary>
    /// Заказчик - Тип дней
    /// </summary>
    public string? CustomerDaysType { get; set; }

    /// <summary>
    /// Агент
    /// </summary>
    public string? Agent { get; set; }

    /// <summary>
    /// Агент - Документ
    /// </summary>
    public string? AgnetDoc { get; set; }

    /// <summary>
    /// Агент - Дата
    /// </summary>
    public string? AgentDateType { get; set; }

    /// <summary>
    /// Агент - Количество дней
    /// </summary>
    public int? AgentDaysAmount { get; set; }

    /// <summary>
    /// Агент - Тип дней
    /// </summary>
    public string? AgentDaysType { get; set; }

    /// <summary>
    /// Поставщик
    /// </summary>
    public string? Supplier { get; set; }

    /// <summary>
    /// Поставщик - Документ
    /// </summary>
    public string? SupplierDoc { get; set; }

    /// <summary>
    /// Поставщик - Дата
    /// </summary>
    public string? SupplierDateType { get; set; }

    /// <summary>
    /// Поставщик - Количество дней
    /// </summary>
    public int? SupplierDaysAmount { get; set; }

    /// <summary>
    /// Поставщик - Тип дней
    /// </summary>
    public string? SupplierDaysType { get; set; }

    /// <summary>
    /// Объем поставки, с НДС Поставщик
    /// </summary>
    public decimal? SupplierPriceNds { get; set; }

    /// <summary>
    /// Объем поставки, с НДС Заказчик
    /// </summary>
    public decimal? CustomerPriceNds { get; set; }

    /// <summary>
    /// Комиссия, %
    /// </summary>
    public decimal? CommissionPercent { get; set; }

    /// <summary>
    /// Среднее количество дней кассового разрыва
    /// </summary>
    public int? CashGapDaysAvg { get; set; }

    /// <summary>
    /// Стоимость ДС, %
    /// </summary>
    public decimal? PriceDsPercent { get; set; }

    /// <summary>
    /// Маржинальность сделки, %
    /// </summary>
    public decimal? MarginPercent { get; set; }

    /// <summary>
    /// Статус
    /// </summary>
    public string? DealState { get; set; }

    /// <summary>
    /// Дата запроса
    /// </summary>
    public DateOnly? QueryDateStr { get; set; }

    /// <summary>
    /// Дата поставки плановая
    /// </summary>
    public DateOnly? DeliveryDatePlan { get; set; }

    /// <summary>
    /// Дата поставки фактическая
    /// </summary>
    public DateOnly? DeliveryDateFact { get; set; }

    /// <summary>
    /// Закупщик
    /// </summary>
    public string? PersonBo { get; set; }

    /// <summary>
    /// Срок изготовления, дн
    /// </summary>
    public int? ProductionTime { get; set; }

    /// <summary>
    /// Д/з Логистика
    /// </summary>
    public decimal? ExpenseLogistic { get; set; }

    /// <summary>
    /// Д/з ИК
    /// </summary>
    public decimal? ExpenseIc { get; set; }

    /// <summary>
    /// Д/з Агентское в-е
    /// </summary>
    public decimal? ExpenseAgent { get; set; }

    /// <summary>
    /// Д/з Прочие
    /// </summary>
    public decimal? ExpenseOther { get; set; }

    /// <summary>
    /// Сложная сделка
    /// </summary>
    public bool? IsComplicated { get; set; }

    /// <summary>
    /// ОБС счет
    /// </summary>
    public bool? IsObsAccount { get; set; }

    /// <summary>
    /// Отправлено в 1С-Документооборот
    /// </summary>
    public bool? IsSended1cdoc { get; set; }

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

    /// <summary>
    /// Стоимость ДС, год
    /// </summary>
    public decimal? CashRate { get; set; }

    /// <summary>
    /// Исходный объем поставки, с НДС Заказчик
    /// </summary>
    public decimal? CustomerPriceSource { get; set; }

    /// <summary>
    /// UUID сделки
    /// </summary>
    public Guid DealUuid { get; set; }

    public DateTime? UpdatedAtXls { get; set; }

    public DateTime? CreatedAtXls { get; set; }

    public bool? IsAutomaticInit { get; set; }

    public long? SupplierId { get; set; }

    /// <summary>
    /// Комиссия Фактическая, % (для попозиционной разбивки в сложных и простых сделках)
    /// </summary>
    public decimal? CommissionPercentFact { get; set; }

    /// <summary>
    /// Валюта ISO 4217
    /// </summary>
    public string Currency { get; set; } = null!;

    /// <summary>
    /// Курс
    /// </summary>
    public decimal? ExchangeRate { get; set; }

    /// <summary>
    /// Направление ЦЗС (Продукт)
    /// </summary>
    public string? DirectionCzs { get; set; }

    /// <summary>
    /// Объем с НДС, Поставщик, Валюта
    /// </summary>
    public decimal? SupplierPriceCurNds { get; set; }

    /// <summary>
    /// Объем с НДС, Заказчик, Валюта
    /// </summary>
    public decimal? CustomerPriceCurNds { get; set; }

    /// <summary>
    /// Создано
    /// </summary>
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Логин
    /// </summary>
    public string? CreatedBy { get; set; }

    /// <summary>
    /// Ответственный по сделке
    /// </summary>
    public string? PersonLogin { get; set; }

    public virtual ICollection<DealCondition> DealConditions { get; set; } = new List<DealCondition>();

    public virtual Procedure Procedure { get; set; } = null!;
}