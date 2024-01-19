namespace BackofficeClient.Models.DataGrid;

public class Request
{
    public long? RequestId { get; }
    public string? RequestNum { get; }
    public DateOnly? RequestDate { get; }
    public string? RequestName { get; }
    public string? Customer { get; }
    public string? NameShort { get; }
    public string? GroupMtr { get; }
    public string? SupState { get; }
    public long? Np { get; }
    public long? Nl { get; }
    public string? RequestComment { get; }
    public string? Priority { get; }
    public decimal? SumIncPrice { get; }
    public string? PersonManager { get; }
    public string TradeSign { get; }
    public string? TradeSignFullname { get; }
    public bool ToWarehouse { get; }
    public bool ToReserve { get; }

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