namespace BackofficeClient.ViewModels;

public class RequestsViewModel
{
    public IEnumerable<object> Items { get; set; }

    public RequestsViewModel()
    {
        using DatabaseContext db = new();

        Items = db.VRequestForms.Join(db.Requests,
            t1 => t1.RequestId,
            t2 => t2.RequestId,
            (t1, t2) => new { t1.RequestId, t1.RequestNum, t1.RequestDate, t1.RequestName, t1.Customer, t1.NameShort, t1.GroupMtr, t1.SupState, t1.Np, t1.Nl, t1.RequestComment, t1.Priority, t1.SumIncPrice, t1.PersonManager, t2.TradeSign })
            .ToList();
    }
}
