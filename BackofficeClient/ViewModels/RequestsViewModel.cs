using CommunityToolkit.Mvvm.Input;
using BackofficeClient.Models.DataDrid;

namespace BackofficeClient.ViewModels;

public class RequestsViewModel : ViewModelBase
{
    public IEnumerable<Request> AllItems { get; set; } = new List<Request>();

    public IEnumerable<Request> FilteredItems { get; set; } = new List<Request>();

    public string RequestNumberFilter { get; set; }

    public string RequestCustomerFilter { get; set; }

    public string RequestNameFilter { get; set; }

    public string RequestDirectioFilter { get; set; }

    public string RequestStatusFilter { get; set; }


    public RelayCommand DataLoadingCommand => new(async () =>
    {
        using DatabaseContext db = new();

        await Task.Run(() =>
            AllItems = db.VRequestForms.Join(db.Requests,
                t1 => t1.RequestId,
                t2 => t2.RequestId,
                (t1, t2) => new Request(t1.RequestId, t1.RequestDate, t1.RequestName, t1.Customer, t1.NameShort, t1.GroupMtr, t1.SupState, t1.Np, t1.Nl, t1.RequestComment, t1.Priority, t1.SumIncPrice, t1.PersonManager, t2.TradeSign))
                .ToList()
            );

        FilteredItems = AllItems;
        OnPropertyChanged("FilteredItems");
    });
    public RelayCommand DataFilteredCommand => new(async () =>
    {
        if (AllItems == null || FilteredItems == null)
        {
            return;
        }

        await Task.Run(() =>
        {
            FilteredItems = AllItems;

            if (!string.IsNullOrWhiteSpace(RequestNumberFilter))
            {
                FilteredItems = FilteredItems.Where(x => x.RequestNum == RequestNumberFilter);
            }
            if (!string.IsNullOrWhiteSpace(RequestCustomerFilter))
            {
                FilteredItems = FilteredItems.Where(x => x.Customer == RequestCustomerFilter);
            }
            if (!string.IsNullOrWhiteSpace(RequestNameFilter))
            {
                FilteredItems = FilteredItems.Where(x => x.RequestName == RequestNameFilter);
            }
            if (!string.IsNullOrWhiteSpace(RequestDirectioFilter))
            {
                FilteredItems = FilteredItems.Where(x => x.PersonManager == RequestDirectioFilter);
            }
            if (!string.IsNullOrWhiteSpace(RequestStatusFilter))
            {
                //var t = FilteredItems.First().TradeSign;
                //var c = RequestStatusFilter;
                FilteredItems = FilteredItems.Where(x => x.TradeSign == RequestStatusFilter);
            }
        });

        OnPropertyChanged("FilteredItems");
    });
    public RequestsViewModel()
    {

    }
}
