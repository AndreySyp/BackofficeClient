namespace BackofficeClient.Models.DataGrid;

public class Position
{
    public string? PositionId { get; }
    public string? RequestNum { get; }
    public DateOnly? RequestDate { get; }
    public string? PositionNum { get; }
    public string? MtrName { get; }
    public string? GroupMtr { get; }
    public string? DocNtd { get; }
    public decimal? Amount { get; }
    public string? Measure { get; }
    public string? DeliveryTime { get; }
    public string? Basis { get; }
    public string? Condition { get; }
    public string? Nmck { get; }
    public string? Currency { get; }
    public string? ProcedureGpb { get; }
    public string? ProcedureGpb4 { get; }
    public string? SupState { get; }
    public string? Person { get; }
    public string? DateCustomerQuery { get; }
    public string? DateDocs { get; }
    public string? DateAgreement { get; }
    public string? DateAs { get; }
    public string? SupName { get; }
    public string? Timing { get; }
    public int? TimingMax { get; }
    public decimal? IncPrice { get; }
    public decimal? IncPriceNds { get; }
    public string? Manufacturer { get; }
    public decimal? IncPriceCur { get; }
    public decimal? IncPriceCurNds { get; }
    public decimal? ExchangeRate { get; }
    public decimal? Price { get; }
    public decimal? PriceNds { get; }
    public decimal? PriceCur { get; }
    public decimal? PriceCurNds { get; }
    public DateTime? UpdatedAt { get; }
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
