using System.ComponentModel;
using static BackofficeClient.Views.MainWindowPages.Requests;

namespace BackofficeClient.Models.DataGrid;

public class Request
{
    public long? RequestId { get; set; }

    [ColumnName("Номер заявки")]
    public string? RequestNum { get; set; }

    [ColumnName("Дата создания заявки")]
    public DateOnly? RequestDate { get; set; }

    [ColumnName("Наименование заявки")]
    public string? RequestName { get; set; }

    [ColumnName("Контрагент")]
    public string? Customer { get; set; }

    [ColumnName("Сегментация клиента")]
    public string? NameShort { get; set; }

    [ColumnName("Группа МТР")]
    public string? GroupMtr { get; set; }

    [ColumnName("Статус позиций")]
    public string? SupState { get; set; }

    [ColumnName("Позиций")]
    public long? Np { get; set; }

    [ColumnName("Лотов")]
    public long? Nl { get; set; }

    public string? RequestComment { get; set; }

    public string? Priority { get; set; }

    [ColumnName("Вх.Стоимость руб. без НДС")]
    public decimal? SumIncPrice { get; set; }

    [ColumnName("Направление ЦЗС")]
    public string? PersonManager { get; set; }

    public string TradeSign { get; set; }

    [ColumnName("Признак сделки")]
    public string? TradeSignFullname { get; set; }

    [ColumnName("На складе")]
    public bool ToWarehouse { get; set; }

    [ColumnName("Номер заявки")]
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