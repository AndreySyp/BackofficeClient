namespace BackofficeClient.Models.Database;

public class DealCondition
{
    public long DealConditionId { get; set; }

    public Guid? DealConditionUuid { get; set; }

    /// <summary>
    /// Идентификатор
    /// </summary>
    public long? DealId { get; set; }

    /// <summary>
    /// Заказчик
    /// </summary>
    public string? Customer { get; set; }

    /// <summary>
    /// Заказчик - Документ
    /// </summary>
    public string? CustomerDoc { get; set; }

    public string? CustomerDate { get; set; }

    /// <summary>
    /// Заказчик - Количество дней
    /// </summary>
    public int? CustomerDaysAmount { get; set; }

    /// <summary>
    /// Заказчик - Тип дней
    /// </summary>
    public string? CustomerDaysType { get; set; }

    /// <summary>
    /// Объем поставки, тыс.руб. с НДС Заказчик
    /// </summary>
    public double? CustomerPrice { get; set; }

    /// <summary>
    /// Исходный объем поставки, с НДС Заказчик
    /// </summary>
    public double? CustomerPriceSource { get; set; }

    /// <summary>
    /// Поставщик
    /// </summary>
    public string? SupName { get; set; }

    /// <summary>
    /// Поставщик - Документ
    /// </summary>
    public string? SupplierDoc { get; set; }

    public string? SupplierDate { get; set; }

    /// <summary>
    /// Поставщик - Количество дней
    /// </summary>
    public int? SupplierDaysAmount { get; set; }

    /// <summary>
    /// Поставщик - Тип дней
    /// </summary>
    public string? SupplierDaysType { get; set; }

    /// <summary>
    /// Объем поставки, тыс.руб. с НДС Поставщик
    /// </summary>
    public double? SumIncPriceNds { get; set; }

    public double? TotalPriceNds { get; set; }

    /// <summary>
    /// Комиссия, %
    /// </summary>
    public decimal? CommissionPercent { get; set; }

    /// <summary>
    /// Среднее количество дней кассового разрыва
    /// </summary>
    public decimal? CashGapDaysAvg { get; set; }

    /// <summary>
    /// Стоимость ДС, %
    /// </summary>
    public decimal? PriceDsPercent { get; set; }

    /// <summary>
    /// Маржинальность сделки, %
    /// </summary>
    public decimal? MarginPercent { get; set; }

    /// <summary>
    /// Дата поставки плановая
    /// </summary>
    public DateOnly? DeliveryDatePlan { get; set; }

    /// <summary>
    /// Дата поставки фактическая
    /// </summary>
    public DateOnly? DeliveryDateFact { get; set; }

    /// <summary>
    /// Стоимость ДС, год
    /// </summary>
    public decimal? CashRate { get; set; }

    /// <summary>
    /// Схема
    /// </summary>
    public string? Scheme { get; set; }

    /// <summary>
    /// Сложная сделка
    /// </summary>
    public bool? IsComplicated { get; set; }

    /// <summary>
    /// ОБС счет
    /// </summary>
    public bool? IsObsAccount { get; set; }

    public decimal? ProductPercent { get; set; }

    public decimal? ExpensePercent { get; set; }

    /// <summary>
    /// Д/з Логистика %
    /// </summary>
    public decimal? ExpenseLogisticPercent { get; set; }

    /// <summary>
    /// Д/з ИК %
    /// </summary>
    public decimal? ExpenseIcPercent { get; set; }

    /// <summary>
    /// Д/з Агентское в-е %
    /// </summary>
    public decimal? ExpenseAgentPercent { get; set; }

    /// <summary>
    /// Д/з Прочие  %
    /// </summary>
    public decimal? ExpenseOtherPercent { get; set; }

    public decimal? Expense { get; set; }

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

    public decimal? SupplierPercent { get; set; }

    /// <summary>
    /// Логин пользователя
    /// </summary>
    public string? UpdatedBy { get; set; }

    /// <summary>
    /// Дата и время последнего изменения
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Объем поставки с НДС, Заказчик, Валюта
    /// </summary>
    public double? CustomerPriceCur { get; set; }

    /// <summary>
    /// Объем поставки с НДС, Заказчик, Валюта
    /// </summary>
    public double? CustomerPriceSourceCur { get; set; }

    /// <summary>
    /// Объем поставки с НДС, Поставщик, Валюта
    /// </summary>
    public double? SumIncPriceCurNds { get; set; }

    /// <summary>
    /// Объем поставки с НДС, Поставщик, Валюта
    /// </summary>
    public double? TotalPriceCurNds { get; set; }

    /// <summary>
    /// Доп. затраты, Всего, Валюта
    /// </summary>
    public decimal? ExpenseCur { get; set; }

    /// <summary>
    /// Доп. затраты, Логистика, Валюта
    /// </summary>
    public decimal? ExpenseLogisticCur { get; set; }

    /// <summary>
    /// Доп. затраты, ИК, Валюта
    /// </summary>
    public decimal? ExpenseIcCur { get; set; }

    /// <summary>
    /// Доп. затраты, Агентские, Валюта
    /// </summary>
    public decimal? ExpenseAgentCur { get; set; }

    /// <summary>
    /// Доп. затраты, Прочие, Валюта
    /// </summary>
    public decimal? ExpenseOtherCur { get; set; }

    public virtual Deal? Deal { get; set; }
}