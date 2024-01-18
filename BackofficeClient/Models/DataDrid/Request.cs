namespace BackofficeClient.Models.DataDrid;

public class Request
{
    public Request(long? requestId, DateOnly? requestDate, string? requestName, string? customer, string? nameShort, string? groupMtr, string? supState, long? np, long? nl, string? requestComment, string? priority, decimal? sumIncPrice, string? personManager, string tradeSign)
    {
        RequestId = requestId;
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
    }

    public long? RequestId { get; internal set; }
    public string? RequestNum { get; internal set; }
    public DateOnly? RequestDate { get; internal set; }
    public string? RequestName { get; internal set; }
    public string? Customer { get; internal set; }
    public string? NameShort { get; internal set; }
    public string? GroupMtr { get; internal set; }
    public string? SupState { get; internal set; }
    public long? Np { get; internal set; }
    public long? Nl { get; internal set; }
    public string? RequestComment { get; internal set; }
    public string? Priority { get; internal set; }
    public decimal? SumIncPrice { get; internal set; }
    public string? PersonManager { get; internal set; }
    public string? TradeSign { get; internal set; }
}
