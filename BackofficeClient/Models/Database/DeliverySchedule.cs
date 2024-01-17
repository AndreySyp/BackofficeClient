namespace BackofficeClient.Models.Database;

public class DeliverySchedule
{
    /// <summary>
    /// Внутренний идентификатор частичной отгрузки
    /// </summary>
    public long DeliveryScheduleId { get; set; }

    /// <summary>
    /// Идентификатор позиции поставки
    /// </summary>
    public long SupplyPositionId { get; set; }

    /// <summary>
    /// Единица измерения
    /// </summary>
    public string? Measure { get; set; }

    /// <summary>
    /// Количество
    /// </summary>
    public decimal? Amount { get; set; }

    /// <summary>
    /// Стоимость с Поставщиком, с НДС
    /// </summary>
    public decimal? SupplierPriceNds { get; set; }

    /// <summary>
    /// Прогнозная дата
    /// </summary>
    public DateOnly? ShippingDate { get; set; }

    /// <summary>
    /// Стоимость с Заказчиком, без НДС
    /// </summary>
    public decimal? CustomerPrice { get; set; }

    /// <summary>
    /// УПД, номер
    /// </summary>
    public string? IncUpdNum { get; set; }

    /// <summary>
    /// УПД, дата
    /// </summary>
    public DateOnly? IncUpdDate { get; set; }

    /// <summary>
    /// Комментарий
    /// </summary>
    public string? DeliveryScheduleComment { get; set; }

    /// <summary>
    /// Статус
    /// </summary>
    public string SupState { get; set; } = null!;

    /// <summary>
    /// Валюта
    /// </summary>
    public string? Currency { get; set; }

    /// <summary>
    /// Обменный курс к рублю
    /// </summary>
    public decimal? ExchangeRate { get; set; }

    /// <summary>
    /// Цена Поставщик, валюта
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
    /// Создано
    /// </summary>
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Обновлено
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Обновлено (логин)
    /// </summary>
    public string? UpdatedBy { get; set; }

    /// <summary>
    /// Цена Поставщик, руб.
    /// </summary>
    public decimal? SupplierPriceUnit { get; set; }

    public virtual SupplyPosition SupplyPosition { get; set; } = null!;
}