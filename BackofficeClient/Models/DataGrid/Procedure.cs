using static BackofficeClient.Infrastructure.Attributes;

namespace BackofficeClient.Models.DataGrid;

public class Procedure
{

    [ColumnName("ID")]
    public long? Id { get; }

    [ColumnName("Процедура ГПБ")]
    public string? ProcedureGpb { get; }

    [ColumnName("Процедура ГПБ на 4")]
    public string? ProcedureGpb4 { get; }     

    [ColumnName("Номер Заявки")]
    public string? RequestNum { get; }        

    [ColumnName("Наименование процедуры")]
    public string? ProcedureName { get; }     

    [ColumnName("Статус закупки")]
    public string? SupState { get; }          

    [ColumnName("Количество заявок")]
    public long? Nr { get; }                  

    [ColumnName("Количество позиций")]
    public long? Np { get; }                  

    [ColumnName("Участники")]
    public string? Members { get; }           

    [ColumnName("Победители")]
    public string? SupName { get; }           

    [ColumnName("Дата окончания приема заявок")]
    public DateOnly? ProcedureDateEnd { get; }

    [ColumnName("Комментарий")]
    public string? ProcedureComment { get; }  

    [ColumnName("Ответственный")]
    public string? Person { get; }            

    [ColumnName("Сумма")]
    public decimal? SumIncPrice { get; }      

    [ColumnName("Сумма с НДС")]
    public decimal? SumIncPriceNds { get; }   

    [ColumnName("Дата публикации")]
    public DateOnly? ProcedureDateBeg { get; }

    [ColumnName("Дата регистрации сделки")]
    public string? DealDate { get; }

    public string? LastTkpLink { get; }

    [ColumnName("Группы МТР")]
    public string? GroupMtr { get; }

    public Procedure(long? id, string? procedureGpb, string? procedureGpb4, string? requestNum, string? procedureName, string? supState, long? nr, long? np, string? members, string? supName, DateOnly? procedureDateEnd, string? procedureComment, string? person, decimal? sumIncPrice, decimal? sumIncPriceNds, DateOnly? procedureDateBeg, string? dealDate, string? lastTkpLink, string? groupMtr)
    {
        Id = id;
        ProcedureGpb = procedureGpb;
        ProcedureGpb4 = procedureGpb4;
        RequestNum = requestNum;
        ProcedureName = procedureName;
        SupState = supState;
        Nr = nr;
        Np = np;
        Members = members;
        SupName = supName;
        ProcedureDateEnd = procedureDateEnd;
        ProcedureComment = procedureComment;
        Person = person;
        SumIncPrice = sumIncPrice;
        SumIncPriceNds = sumIncPriceNds;
        ProcedureDateBeg = procedureDateBeg;
        DealDate = dealDate;
        LastTkpLink = lastTkpLink;
        GroupMtr = groupMtr;
    }
}
