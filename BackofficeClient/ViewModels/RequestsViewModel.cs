using BackofficeClient.Models.DataGrid;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BackofficeClient.ViewModels;

public class RequestsViewModel : ViewModelBase
{
    #region Объекты для привязки

    public ObservableCollection<Request> AllItems { get; set; } = [];

    public ObservableCollection<Request> FilteredItems { get; set; } = [];

    #region Поиск

    public string? RequestNumberFilter { get; set; }

    public string? RequestCustomerFilter { get; set; }

    public string? RequestNameFilter { get; set; }

    public string? RequestDirectioFilter { get; set; }

    public string? RequestStatusFilter { get; set; }

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

    #region Команды

    public AsyncRelayCommand DataLoadingCommand => new(async () =>
    {
        using DatabaseContext db = new();

        // Legacy request join v_request
        await Task.Run(() => AllItems = new(
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
        .OrderByDescending(r => r.RequestDate)));

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
            IEnumerable<Request> filteredItems = AllItems.ToList();

            if (!string.IsNullOrWhiteSpace(RequestNumberFilter))
            {
                filteredItems = filteredItems.Where(x => x.RequestNum == RequestNumberFilter);
            }
            if (!string.IsNullOrWhiteSpace(RequestCustomerFilter))
            {
                filteredItems = filteredItems.Where(x => x.Customer == RequestCustomerFilter);
            }
            if (!string.IsNullOrWhiteSpace(RequestNameFilter))
            {
                filteredItems = filteredItems.Where(x => x.RequestName == RequestNameFilter);
            }
            if (!string.IsNullOrWhiteSpace(RequestDirectioFilter))
            {
                filteredItems = filteredItems.Where(x => x.PersonManager == RequestDirectioFilter);
            }
            if (!string.IsNullOrWhiteSpace(RequestStatusFilter))
            {
                filteredItems = filteredItems.Where(x => x.SupState == RequestStatusFilter);
            }

            FilteredItems = new(filteredItems);
        });

        OnPropertyChanged("FilteredItems");
    });

    public RelayCommand FillingEditFields => new(async () =>
    {
        await Task.Run(() =>
        {
            RequestPriorityEdit = "asdsad";
            OnPropertyChanged("RequestPriorityEdit");

            RequestCommentEdit = "asdsad";
            OnPropertyChanged("RequestCommentEdit");

            RequestCustomerEdit = "asdsad";
            OnPropertyChanged("RequestCustomerEdit");

            RequestDirectionEdit = "asdsad";
            OnPropertyChanged("RequestDirectionEdit");

            RequestTradeSignEdit = "asdsad";
            OnPropertyChanged("RequestTradeSignEdit");

            RequestToWarehouseEdit = true;
            OnPropertyChanged("RequestToWarehouseEdit");

            RequestToReserveEdit = true;
            OnPropertyChanged("RequestToReserveEdit");

            //if (SelectedItems == null) { return; }

            //RequestPriorityEdit = SelectedItems.Priority;
            //OnPropertyChanged("RequestPriorityEdit");

            //RequestCommentEdit = SelectedItems.RequestComment;
            //OnPropertyChanged("RequestCommentEdit");

            //RequestCustomerEdit = SelectedItems.Customer;
            //OnPropertyChanged("RequestCustomerEdit");

            //RequestDirectionEdit = SelectedItems.PersonManager;
            //OnPropertyChanged("RequestDirectionEdit");

            //RequestTradeSignEdit = SelectedItems.TradeSign;
            //OnPropertyChanged("RequestTradeSignEdit");

            //RequestToWarehouseEdit = SelectedItems.ToWarehouse;
            //OnPropertyChanged("RequestToWarehouseEdit");

            //RequestToReserveEdit = SelectedItems.ToReserve;
            //OnPropertyChanged("RequestToReserveEdit");
        });
    });

    #endregion


    public RequestsViewModel()
    {
        FilteredItems = [new() { Customer = "asd" }, new() { Priority = "asd" }];
        OnPropertyChanged("FilteredItems");
    }
}
