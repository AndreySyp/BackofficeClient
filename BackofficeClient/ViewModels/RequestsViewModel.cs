using BackofficeClient.Models.DataGrid;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BackofficeClient.ViewModels;

public class RequestsViewModel : ViewModelBase
{
    #region Объекты для привязки

    public ObservableCollection<Request> AllItems { get; set; } = [];

    public ObservableCollection<Request> SelectedItems { get; set; } = [];


    private ObservableCollection<Request> filteredItems = [];
    public ObservableCollection<Request> FilteredItems
    {
        get => filteredItems;
        set {filteredItems = value; OnPropertyChanged("FilteredItems"); }
    }

    private bool isLoading = false;
    public bool IsLoading
    {
        get => isLoading;
        set { isLoading = value; OnPropertyChanged("IsLoading"); }
    }

    #region Поиск

    private string? requestNumberFilter;
    public string? RequestNumberFilter
    {
        get => requestNumberFilter;
        set { requestNumberFilter = value; OnPropertyChanged("RequestNumberFilter"); }
    }

    private string? requestCustomerFilter;
    public string? RequestCustomerFilter
    {
        get => requestCustomerFilter;
        set { requestCustomerFilter = value; OnPropertyChanged("RequestCustomerFilter"); }
    }

    private string? requestNameFilter;
    public string? RequestNameFilter
    {
        get => requestNameFilter;
        set { requestNameFilter = value; OnPropertyChanged("RequestNameFilter"); }
    }

    private string? requestDirectioFilter;
    public string? RequestDirectioFilter
    {
        get => requestDirectioFilter;
        set { requestDirectioFilter = value; OnPropertyChanged("RequestDirectioFilter"); }
    }

    private string? requestStatusFilter;
    public string? RequestStatusFilter
    {
        get => requestStatusFilter;
        set { requestStatusFilter = value; OnPropertyChanged("RequestStatusFilter"); }
    }

    #endregion

    #region Редактирование

    private string? requestPriorityEdit;
    public string? RequestPriorityEdit
    { 
        get => requestPriorityEdit; 
        set { requestPriorityEdit = value; OnPropertyChanged("RequestPriorityEdit"); } 
    }

    private string? requestCommentEdit;
    public string? RequestCommentEdit
    { 
        get => requestCommentEdit; 
        set { requestCommentEdit = value; OnPropertyChanged("RequestCommentEdit"); } 
    }

    private string? requestCustomerEdit;
    public string? RequestCustomerEdit
    { 
        get => requestCustomerEdit; 
        set { requestCustomerEdit = value; OnPropertyChanged("RequestCustomerEdit"); } 
    }

    private string? requestDirectionEdit;
    public string? RequestDirectionEdit
    { 
        get => requestDirectionEdit; 
        set { requestDirectionEdit = value; OnPropertyChanged("RequestDirectionEdit"); } 
    }

    private string? requestTradeSignEdit;
    public string? RequestTradeSignEdit
    { 
        get => requestTradeSignEdit; 
        set { requestTradeSignEdit = value; OnPropertyChanged("RequestTradeSignEdit"); } 
    }

    private bool? requestToWarehouseEdit;
    public bool? RequestToWarehouseEdit
    { 
        get => requestToWarehouseEdit; 
        set { requestToWarehouseEdit = value; OnPropertyChanged("RequestToWarehouseEdit"); } 
    }

    private bool? requestToReserveEdit;
    public bool? RequestToReserveEdit
    { 
        get => requestToReserveEdit; 
        set { requestToReserveEdit = value; OnPropertyChanged("RequestToReserveEdit"); } 
    }

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
    });

    public RelayCommand DataFilteredCommand => new(async () =>
    {
        IsLoading = true;

        await Task.Run(() =>
        {

            Task.Delay(2000000);

        });

        //IsLoading = false;
        //OnPropertyChanged("IsLoading");
        ;
        return;
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

    });

    public RelayCommand FillingEditFields => new(async () =>
    {
        await Task.Run(() =>
        {
            RequestPriorityEdit = "asdsad";
            RequestCommentEdit = "asdsad";
            RequestCustomerEdit = "asdsad";
            RequestDirectionEdit = "asdsad";
            RequestTradeSignEdit = "asdsad";
            RequestToWarehouseEdit = true;
            RequestToReserveEdit = true;

            //if (SelectedItems == null) { return; }
            //RequestPriorityEdit = SelectedItems.Priority;
            //RequestCommentEdit = SelectedItems.RequestComment;
            //RequestCustomerEdit = SelectedItems.Customer;
            //RequestDirectionEdit = SelectedItems.PersonManager;
            //RequestTradeSignEdit = SelectedItems.TradeSign;
            //RequestToWarehouseEdit = SelectedItems.ToWarehouse;
            //RequestToReserveEdit = SelectedItems.ToReserve;
        });
    });

    #endregion


    public RequestsViewModel()
    {
        FilteredItems = [new() { Customer = "asd" }, new() { Priority = "asd" }];
    }
}
