namespace BackofficeClient.Models.Database;

public class Position
{
    /// <summary>
    /// ID
    /// </summary>
    public long PositionId { get; set; }

    /// <summary>
    /// Заявка
    /// </summary>
    public long? RequestId { get; set; }

    public Guid? RequestUuid { get; set; }

    /// <summary>
    /// Номер заявки
    /// </summary>
    public string? RequestNum { get; set; }

    /// <summary>
    /// Номер позиции
    /// </summary>
    public string? PositionNum { get; set; }

    /// <summary>
    /// Наименование МТР
    /// </summary>
    public string? MtrName { get; set; }

    /// <summary>
    /// Нормативный документ
    /// </summary>
    public string? DocNtd { get; set; }

    /// <summary>
    /// Количество
    /// </summary>
    public decimal? Amount { get; set; }

    /// <summary>
    /// Единица измерения
    /// </summary>
    public string? Measure { get; set; }

    /// <summary>
    /// Необходимый срок поставки
    /// </summary>
    public string? DeliveryTime { get; set; }

    /// <summary>
    /// Базис поставки
    /// </summary>
    public string? Basis { get; set; }

    /// <summary>
    /// Условия оплаты
    /// </summary>
    public string? Condition { get; set; }

    /// <summary>
    /// Начальная максимальная цена
    /// </summary>
    public string? Nmck { get; set; }

    /// <summary>
    /// Валюта
    /// </summary>
    public string Currency { get; set; } = null!;

    /// <summary>
    /// Идентификатор группы МТР
    /// </summary>
    public long? GroupMtrId { get; set; }

    /// <summary>
    /// Группа МТР
    /// </summary>
    public string? GroupMtr { get; set; }

    public string? GroupMtrPrcUuid { get; set; }

    /// <summary>
    /// Процедура ЭТП
    /// </summary>
    public long? ProcedureId { get; set; }

    public Guid? ProcedureUuid { get; set; }

    /// <summary>
    /// Процедура ЭТП
    /// </summary>
    public string? ProcedureGpb { get; set; }

    public string? ProcedureGpb4 { get; set; }

    /// <summary>
    /// Процедура ЭТП на 4 (идентификатор на площадке)
    /// </summary>
    public Guid? PositionUuid { get; set; }

    public decimal? PriceUnit { get; set; }

    public string? StatePrc { get; set; }

    /// <summary>
    /// Ссылка на последнее добавленное значение статуса
    /// </summary>
    public long? SupStateId { get; set; }

    /// <summary>
    /// Победитель
    /// </summary>
    public string? SupName { get; set; }

    /// <summary>
    /// Статус закупки
    /// </summary>
    public string SupState { get; set; } = null!;

    /// <summary>
    /// Ответственный
    /// </summary>
    public string? Person { get; set; }

    public string? PersonUid { get; set; }

    /// <summary>
    /// Дата запроса в адрес Заказчика ТТ/ТЗ/ТУ
    /// </summary>
    public string? DateCustomerQuery { get; set; }

    /// <summary>
    /// Дата получения от Заказчика всей требуемой технической документации
    /// </summary>
    public string? DateDocs { get; set; }

    /// <summary>
    /// Дата отправки Заказчику на согласование АС/ТКП
    /// </summary>
    public string? DateAgreement { get; set; }

    /// <summary>
    /// Дата согласования АС/ТКП
    /// </summary>
    public string? DateAs { get; set; }

    /// <summary>
    /// Сроки поставки по АС
    /// </summary>
    public string? Timing { get; set; }

    /// <summary>
    /// Максимальный срок поставки по АС
    /// </summary>
    public int? TimingMax { get; set; }

    /// <summary>
    /// Вх. стоимость товара без НДС, руб.
    /// </summary>
    public decimal? IncPrice { get; set; }

    /// <summary>
    /// Вх. стоимость товара с НДС, руб.
    /// </summary>
    public decimal? IncPriceNds { get; set; }

    /// <summary>
    /// Обновлено из процессора в рамках периодической загрузки
    /// </summary>
    public DateTime? UpdateOnRegistry { get; set; }

    public DateTime? UpdateOnData { get; set; }

    /// <summary>
    /// Загружено из Отчет 2022
    /// </summary>
    public DateTime? UpdateOnReport2022 { get; set; }

    /// <summary>
    /// Дата последнего обновления
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Изготовитель
    /// </summary>
    public string? Manufacturer { get; set; }

    /// <summary>
    /// Обновлена Позиция МТР
    /// </summary>
    public string UpdatedBy { get; set; } = null!;

    /// <summary>
    /// Поставщик
    /// </summary>
    public long? SupplierId { get; set; }

    /// <summary>
    /// Прогнозная дата отгрузки
    /// </summary>
    public DateOnly? ShippingDate { get; set; }

    /// <summary>
    /// Ответственный
    /// </summary>
    public string? PersonForwarder { get; set; }

    /// <summary>
    /// Входящее УПД. Счет фактура. №
    /// </summary>
    public string? IncUpdNum { get; set; }

    /// <summary>
    /// Входящее УПД. Счет фактура. Дата
    /// </summary>
    public DateOnly? IncUpdDate { get; set; }

    /// <summary>
    /// Комментарий
    /// </summary>
    public string? SupComment { get; set; }

    /// <summary>
    /// Признак отгрузки
    /// </summary>
    public bool IsShipped { get; set; }

    /// <summary>
    /// Объект
    /// </summary>
    public string? SupObject { get; set; }

    /// <summary>
    /// Дата обновления Поставки
    /// </summary>
    public DateTime SupUpdatedAt { get; set; }

    /// <summary>
    /// Обновлена Поставка
    /// </summary>
    public string SupUpdatedBy { get; set; } = null!;

    /// <summary>
    /// Фактическая дата отгрузки
    /// </summary>
    public DateOnly? ShippingDateFact { get; set; }

    public bool? IsAutomaticInit { get; set; }

    public string? MtrNameSrc { get; set; }

    public string? Tolerance { get; set; }

    public string? PaymentTerms { get; set; }

    public string? MtrRequirements { get; set; }

    /// <summary>
    /// ПОЛНОЕ наименование и марка Товара
    /// </summary>
    public string? MtrNameFull { get; set; }

    /// <summary>
    /// Вх. стоимость товара без НДС, валюта.
    /// </summary>
    public decimal? IncPriceCur { get; set; }

    /// <summary>
    /// Вх. стоимость товара с НДС, валюта.
    /// </summary>
    public decimal? IncPriceCurNds { get; set; }

    /// <summary>
    /// Курс
    /// </summary>
    public decimal? ExchangeRate { get; set; }

    /// <summary>
    /// Исходящая стоимость товара без НДС, руб.
    /// </summary>
    public decimal? OutPrice { get; set; }

    /// <summary>
    /// Исходящая стоимость товара c НДС, руб.
    /// </summary>
    public decimal? OutPriceNds { get; set; }

    /// <summary>
    /// Исходящая стоимость товара без НДС, Валюта.
    /// </summary>
    public decimal? OutPriceCur { get; set; }

    /// <summary>
    /// Исходящая стоимость товара c НДС, Валюта.
    /// </summary>
    public decimal? OutPriceCurNds { get; set; }

    /// <summary>
    /// Конечный заказчик
    /// </summary>
    public string? CustomerEnd { get; set; }

    /// <summary>
    /// Материал SAP
    /// </summary>
    public string? MaterialSap { get; set; }

    /// <summary>
    /// Заявка SAP
    /// </summary>
    public string? RequestSap { get; set; }

    /// <summary>
    /// Позиция SAP
    /// </summary>
    public string? PositionSap { get; set; }

    /// <summary>
    /// Логин создавшего Позицию Заявки
    /// </summary>
    public string CreatedBy { get; set; } = null!;

    /// <summary>
    /// Время создания Позиции Заявки
    /// </summary>
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Связанное значение сделки. Устанавливается после инициализации и обновлении условий сделки в cnt.trf_cnt_deal_biu
    /// </summary>
    public long? PositionDealId { get; set; }

    public virtual Procedure? Procedure { get; set; }

    public virtual Request? Request { get; set; }

    public virtual ICollection<SpecPosition> SpecPositions { get; set; } = new List<SpecPosition>();

    public virtual ICollection<SupStateDeleted> SupStateDeleteds { get; set; } = new List<SupStateDeleted>();

    public virtual ICollection<SupState> SupStates { get; set; } = new List<SupState>();
}