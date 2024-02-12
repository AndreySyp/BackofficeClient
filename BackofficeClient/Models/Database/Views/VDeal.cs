namespace BackofficeClient.Models.Database.Views;

public class VDeal
{
    public long? DealId { get; set; }

    public string? DealName { get; set; }

    public string? DocRequestNum { get; set; }

    public string? Comment { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? DocNum { get; set; }

    public string? DocDate { get; set; }

    public long? ProcedureId { get; set; }

    public string? StrRequestNum { get; set; }

    public string? ProcedureGpb { get; set; }

    public string? GroupMtr { get; set; }

    public string? Scheme { get; set; }

    public string? Customer { get; set; }

    public string? CustomerDoc { get; set; }

    public string? CustomerDateType { get; set; }

    public int? CustomerDaysAmount { get; set; }

    public string? CustomerDaysType { get; set; }

    public string? Agent { get; set; }

    public string? AgnetDoc { get; set; }

    public string? AgentDateType { get; set; }

    public int? AgentDaysAmount { get; set; }

    public string? AgentDaysType { get; set; }

    public string? Supplier { get; set; }

    public string? SupplierDoc { get; set; }

    public string? SupplierDateType { get; set; }

    public int? SupplierDaysAmount { get; set; }

    public string? SupplierDaysType { get; set; }

    public decimal? SupplierPriceNds { get; set; }

    public decimal? CustomerPriceNds { get; set; }

    public string? Currency { get; set; }

    public decimal? ExchangeRate { get; set; }

    public decimal? SupplierPriceCurNds { get; set; }

    public decimal? CustomerPriceCurNds { get; set; }

    public int? CashGapDaysAvg { get; set; }

    public decimal? ExpenseTotal { get; set; }

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
    /// Комиссия, %
    /// </summary>
    public decimal? CommissionPercent { get; set; }

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
    /// Дата поставки плановая
    /// </summary>
    public string? DeliveryDatePlan { get; set; }

    /// <summary>
    /// Дата поставки фактическая
    /// </summary>
    public string? DeliveryDateFact { get; set; }

    /// <summary>
    /// Срок изготовления, дн
    /// </summary>
    public int? ProductionTime { get; set; }

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
    /// Направление ЦЗС
    /// </summary>
    public string? PersonManager { get; set; }

    public string? Person { get; set; }

    public string? PersonUpdatedBy { get; set; }

    public DateOnly? DealUpdatedAt { get; set; }

    public DateOnly? DealUpdatedAtXls { get; set; }

    public DateOnly? DealCreatedAtXls { get; set; }

    public string? CreatedBy { get; set; }

    public string? CreatedAtHhmm { get; set; }
}
