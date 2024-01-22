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
        set { filteredItems = value; OnPropertyChanged("FilteredItems"); }
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

    private string? requestNumberEdit;
    public string? RequestNumberEdit
    {
        get => requestNumberEdit;
        set { requestNumberEdit = value; OnPropertyChanged("RequestNumberEdit"); }
    }

    private DateOnly? requestDateEdit;
    public DateOnly? RequestDateEdit
    {
        get => requestDateEdit;
        set { requestDateEdit = value; OnPropertyChanged("RequestDateEdit"); }
    }

    private string? requestNameEdit;
    public string? RequestNameEdit
    {
        get => requestNameEdit;
        set { requestNameEdit = value; OnPropertyChanged("RequestNameEdit"); }
    }

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
        await Task.Run(() =>
        {
            using DatabaseContext db = new();
            IsLoading = true;

            AllItems = new(
                    // Legacy request join v_request
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
        });
    });

    public RelayCommand ClearFilterCommand => new(() =>
    {
        RequestNumberFilter = null;
        RequestCustomerFilter = null;
        RequestNameFilter = null;
        RequestDirectioFilter = null;
        RequestStatusFilter = null;
    });

    public AsyncRelayCommand DataFilteredCommand => new(async () =>
    {
        await Task.Run(() =>
        {
            if (AllItems == null || AllItems.Count == 0)
            {
                DataLoadingCommand.Execute(null);
            }
            if (AllItems == null)
            {
                return;
            }

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

    public RelayCommand FillingEditFields => new(() =>
    {
        if (SelectedItems == null)
        {
            return;
        }

        if (SelectedItems.Count == 1)
        {
            RequestNumberEdit = SelectedItems[0].RequestNum;
            RequestNameEdit = SelectedItems[0].RequestName;
            RequestDateEdit = SelectedItems[0].RequestDate;
        }
        else
        {
            RequestNumberEdit = null;
            RequestNameEdit = null;
            RequestDateEdit = null;
        }

        RequestPriorityEdit = SelectedItems[0].Priority;
        RequestCommentEdit = SelectedItems[0].RequestComment;
        RequestCustomerEdit = SelectedItems[0].Customer;
        RequestDirectionEdit = SelectedItems[0].PersonManager;
        RequestTradeSignEdit = SelectedItems[0].TradeSign;
        RequestToWarehouseEdit = SelectedItems[0].ToWarehouse;
        RequestToReserveEdit = SelectedItems[0].ToReserve;
    });

    #endregion

    public RequestsViewModel()
    {

    }
}
