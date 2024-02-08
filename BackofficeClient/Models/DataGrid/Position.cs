using static BackofficeClient.Infrastructure.Attributes;

namespace BackofficeClient.Models.DataGrid;

public class Position
{

    [ColumnName("ID")]
    public string? PositionId { get; }

    [ColumnName("Номер заявки")]
    public string? RequestNum { get; }

    [ColumnName("Дата создания заявки")]
    public DateOnly? RequestDate { get; }

    [ColumnName("Номер позиции")]
    public string? PositionNum { get; }

    [ColumnName("Наименование МТР")]
    public string? MtrName { get; }

    [ColumnName("Группа МТР")]
    public string? GroupMtr { get; }

    [ColumnName("Документ (НТД)")]
    public string? DocNtd { get; }

    [ColumnName("Количество")]
    public decimal? Amount { get; }

    [ColumnName("Ед. Измерения")]
    public string? Measure { get; }

    [ColumnName("Необходимый срок поставки")]
    public string? DeliveryTime { get; }

    [ColumnName("Базис поставки")]
    public string? Basis { get; }

    [ColumnName("Условия оплаты")]
    public string? Condition { get; }

    [ColumnName("Начальная макс. цена")]
    public string? Nmck { get; }

    [ColumnName("Валюта")]
    public string? Currency { get; }

    [ColumnName("Процедура ГПБ")]
    public string? ProcedureGpb { get; }

    [ColumnName("Процедура ГПБ на 4")]
    public string? ProcedureGpb4 { get; }

    [ColumnName("Статус закупки")]
    public string? SupState { get; }

    [ColumnName("Ответственный")]
    public string? Person { get; }

    [ColumnName("Дата запроса в адрес заказчика ТТ")]
    public string? DateCustomerQuery { get; }

    [ColumnName("Дата получения от заказчика ТТ/ТУ")]
    public string? DateDocs { get; }

    [ColumnName("Дата отправки заказчику на согл.")]
    public string? DateAgreement { get; }

    [ColumnName("Дата согласования АС заказчиком")]
    public string? DateAs { get; }

    [ColumnName("Победитель")]
    public string? SupName { get; }

    [ColumnName("Сроки поставки по АС")]
    public string? Timing { get; }

    [ColumnName("Макс. сроки поставки по АС")]
    public int? TimingMax { get; }

    [ColumnName("Вх. стоимость товара без НДС, руб")]
    public decimal? IncPrice { get; }

    [ColumnName("Вх. стоимость товара с НДС, руб")]
    public decimal? IncPriceNds { get; }

    [ColumnName("Изготовитель")]
    public string? Manufacturer { get; }

    [ColumnName("Вх. стоимость товара без НДС, валюта")]
    public decimal? IncPriceCur { get; }

    [ColumnName("Вх. стоимость товара с НДС, валюта")]
    public decimal? IncPriceCurNds { get; }

    [ColumnName("Курс валюты")]
    public decimal? ExchangeRate { get; }

    [ColumnName("Исх. стоимость товара без НДС, руб")]
    public decimal? Price { get; }

    [ColumnName("Исх. стоимость товара с НДС, руб")]
    public decimal? PriceNds { get; }

    [ColumnName("Исх. стоимость товара без НДС, валюта")]
    public decimal? PriceCur { get; }

    [ColumnName("Исх. стоимость товара с НДС, валюта")]
    public decimal? PriceCurNds { get; }

    [ColumnName("Последнее изменение в")]
    public DateTime? UpdatedAt { get; }

    [ColumnName("Объект")]
    public string? SupObject { get; }

    public Position(string? positionId, string? requestNum, DateOnly? requestDate, string? positionNum, string? mtrName, string? groupMtr, string? docNtd, decimal? amount, string? measure, string? deliveryTime, string? basis, string? condition, string? nmck, string? currency, string? procedureGpb, string? procedureGpb4, string? supState, string? person, string? dateCustomerQuery, string? dateDocs, string? dateAgreement, string? dateAs, string? supName, string? timing, int? timingMax, decimal? incPrice, decimal? incPriceNds, string? manufacturer, decimal? incPriceCur, decimal? incPriceCurNds, decimal? exchangeRate, decimal? price, decimal? priceNds, decimal? priceCur, decimal? priceCurNds, DateTime? updatedAt, string? supObject)
    {
        PositionId = positionId;
        RequestNum = requestNum;
        RequestDate = requestDate;
        PositionNum = positionNum;
        MtrName = mtrName;
        GroupMtr = groupMtr;
        DocNtd = docNtd;
        Amount = amount;
        Measure = measure;
        DeliveryTime = deliveryTime;
        Basis = basis;
        Condition = condition;
        Nmck = nmck;
        Currency = currency;
        ProcedureGpb = procedureGpb;
        ProcedureGpb4 = procedureGpb4;
        SupState = supState;
        Person = person;
        DateCustomerQuery = dateCustomerQuery;
        DateDocs = dateDocs;
        DateAgreement = dateAgreement;
        DateAs = dateAs;
        SupName = supName;
        Timing = timing;
        TimingMax = timingMax;
        IncPrice = incPrice;
        IncPriceNds = incPriceNds;
        Manufacturer = manufacturer;
        IncPriceCur = incPriceCur;
        IncPriceCurNds = incPriceCurNds;
        ExchangeRate = exchangeRate;
        Price = price;
        PriceNds = priceNds;
        PriceCur = priceCur;
        PriceCurNds = priceCurNds;
        UpdatedAt = updatedAt;
        SupObject = supObject;
    }
}
