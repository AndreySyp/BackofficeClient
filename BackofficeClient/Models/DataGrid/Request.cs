namespace BackofficeClient.Models.DataGrid;

public class Request
{
    public long? RequestId { get; set; }
    public string? RequestNum { get; set; }
    public DateOnly? RequestDate { get; set; }
    public string? RequestName { get; set; }
    public string? Customer { get; set; }
    public string? NameShort { get; set; }
    public string? GroupMtr { get; set; }
    public string? SupState { get; set; }
    public long? Np { get; set; }
    public long? Nl { get; set; }
    public string? RequestComment { get; set; }
    public string? Priority { get; set; }
    public decimal? SumIncPrice { get; set; }
    public string? PersonManager { get; set; }
    public string TradeSign { get; set; }
    public string? TradeSignFullname { get; set; }
    public bool ToWarehouse { get; set; }
    public bool ToReserve { get; set; }

    public Request(long? requestId, string? requestNum, DateOnly? requestDate, string? requestName, string? customer, string? nameShort, string? groupMtr, string? supState, long? np, long? nl, string? requestComment, string? priority, decimal? sumIncPrice, string? personManager, string tradeSign, string? tradeSignFullname, bool toWarehouse, bool toReserve)
    {
        RequestId = requestId;
        RequestNum = requestNum;
        RequestDate = requestDate;
        RequestName = requestName;
        Customer = customer;
        NameShort = nameShort;
        GroupMtr = groupMtr;
        SupState = supState;
        Np = np;
        Nl = nl;
        RequestComment = requestComment;
        Priority = priority;
        SumIncPrice = sumIncPrice;
        PersonManager = personManager;
        TradeSign = tradeSign;
        TradeSignFullname = tradeSignFullname;
        ToWarehouse = toWarehouse;
        ToReserve = toReserve;
    }
}