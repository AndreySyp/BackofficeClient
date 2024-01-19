using BackofficeClient.Models.DataGrid;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Controls;

namespace BackofficeClient.ViewModels;

public class RequestsViewModel : ViewModelBase
{
    #region Объекты для привязки

    #region Поиск
    public IEnumerable<Request> AllItems { get; set; } = new List<Request>();

    public IEnumerable<Request> FilteredItems { get; set; } = new List<Request>();

    public string RequestNumberFilter { get; set; }

    public string RequestCustomerFilter { get; set; }

    public string RequestNameFilter { get; set; }

    public string RequestDirectioFilter { get; set; }

    public string RequestStatusFilter { get; set; }

    #endregion

    #region Редактирование

    public Request? SelectedItems { get; set; }

    public string? RequestPriorityEdit { get; set; }

    public string? RequestCommentEdit { get; set; }

    public string? RequestCustomerEdit { get; set; }

    public string? RequestDirectionEdit { get; set; }

    public string? RequestTradeSignEdit { get; set; }

    public bool? RequestToWarehouseEdit { get; set; }

    public bool? RequestToReserveEdit { get; set; }

    #endregion

    #endregion

    public RelayCommand DataLoadingCommand => new(async () =>
    {
        using DatabaseContext db = new();

        // Legacy request join v_request
        await Task.Run(() => AllItems =
        db.Requests.Join(
            db.TradeSigns,
            r => r.TradeSign,
            ts => ts.TradeSign1,
            (r, ts) => new { r.RequestId, r.TradeSign, ts.TradeSignFullname, r.ToWarehouse, r.ToReserve })
        .Join(
            db.VRequestForms,
            rts => rts.RequestId,
            vr => vr.RequestId,
            (rts, vr) => new Request(vr.RequestId, vr.RequestNum, vr.RequestDate, vr.RequestName, vr.Customer, vr.NameShort, vr.GroupMtr, vr.SupState, vr.Np, vr.Nl, vr.RequestComment, vr.Priority, vr.SumIncPrice, vr.PersonManager, rts.TradeSign, rts.TradeSignFullname, rts.ToWarehouse, rts.ToReserve))
        .ToList()
        .OrderByDescending(r => r.RequestDate));

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
                FilteredItems = FilteredItems.Where(x => x.SupState == RequestStatusFilter);
            }
        });

        OnPropertyChanged("FilteredItems");
    });

    /// <summary>
    /// /////////////////////////////////////////////////////////////
    /// </summary>
    public SelectionChangedEventHandler asd;
    public void DataGrid_Selected(object sender, System.Windows.RoutedEventArgs e)
    {
        dd();
    }

    public void dd()
    {
        if (SelectedItems == null) { return; }

        RequestPriorityEdit = SelectedItems.Priority;
        OnPropertyChanged("RequestPriorityEdit");

        RequestCommentEdit = SelectedItems.RequestComment;
        OnPropertyChanged("RequestCommentEdit");

        RequestCustomerEdit = SelectedItems.Customer;
        OnPropertyChanged("RequestCustomerEdit");

        RequestDirectionEdit = SelectedItems.PersonManager;
        OnPropertyChanged("RequestDirectionEdit");

        RequestTradeSignEdit = SelectedItems.TradeSign;
        OnPropertyChanged("RequestTradeSignEdit");

        RequestToWarehouseEdit = SelectedItems.ToWarehouse;
        OnPropertyChanged("RequestToWarehouseEdit");

        RequestToReserveEdit = SelectedItems.ToReserve;
        OnPropertyChanged("RequestToReserveEdit");


    }
    public RequestsViewModel()
    {
        ///////////////////////////////////////////////
        asd += DataGrid_Selected;
    }
}
