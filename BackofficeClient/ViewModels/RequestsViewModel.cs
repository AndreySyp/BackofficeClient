using BackofficeClient.Infrastructure.Extensions;
using BackofficeClient.Models.DataGrid;
using BackofficeClient.Views.Windows;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BackofficeClient.ViewModels;

/// <summary>
/// Name
/// </summary>


public class RequestsViewModel : ViewModelBase, INterface1
{

    #region Объекты для привязки

    #region Общие

    public ObservableCollection<Request> AllItems { get; set; } = [];

    public ObservableCollection<Request> SelectedItems { get; set; } = [];

    private ObservableCollection<Request> filteredItems = [];
    public ObservableCollection<Request> FilteredItems
    {
        get => filteredItems;
        set { filteredItems = value; OnPropertyChanged(); }
    }

    private bool isLoading = false;
    public bool IsLoading
    {
        get => isLoading;
        set { isLoading = value; OnPropertyChanged(); }
    }

    #endregion

    #region Поиск

    private string? numberFilter;
    public string? NumberFilter
    {
        get => numberFilter;
        set { numberFilter = value; OnPropertyChanged(); }
    }

    private string? customerFilter;
    public string? CustomerFilter
    {
        get => customerFilter;
        set { customerFilter = value; OnPropertyChanged(); }
    }

    private string? nameFilter;
    public string? NameFilter
    {
        get => nameFilter;
        set { nameFilter = value; OnPropertyChanged(); }
    }

    private string? directioFilter;
    public string? DirectioFilter
    {
        get => directioFilter;
        set { directioFilter = value; OnPropertyChanged(); }
    }

    private string? statusFilter;
    public string? StatusFilter
    {
        get => statusFilter;
        set { statusFilter = value; OnPropertyChanged(); }
    }

    #endregion

    #region Редактирование

    #region Одиночное

    private string? numberEdit;
    public string? NumberEdit
    {
        get => numberEdit;
        set { numberEdit = value; OnPropertyChanged(); }
    }

    private DateTime? dateEdit;
    public DateTime? DateEdit
    {
        get => dateEdit;
        set { dateEdit = value; OnPropertyChanged(); }
    }

    private string? nameEdit;
    public string? NameEdit
    {
        get => nameEdit;
        set { nameEdit = value; OnPropertyChanged(); }
    }

    #endregion

    #region Множественное

    private string? priorityEdit;
    public string? PriorityEdit
    {
        get => priorityEdit;
        set { priorityEdit = value; OnPropertyChanged(); }
    }

    private string? commentEdit;
    public string? CommentEdit
    {
        get => commentEdit;
        set { commentEdit = value; OnPropertyChanged(); }
    }

    private string? customerEdit;
    public string? CustomerEdit
    {
        get => customerEdit;
        set { customerEdit = value; OnPropertyChanged(); }
    }

    private string? directionEdit;
    public string? DirectionEdit
    {
        get => directionEdit;
        set { directionEdit = value; OnPropertyChanged(); }
    }

    private string? tradeSignEdit;
    public string? TradeSignEdit
    {
        get => tradeSignEdit;
        set { tradeSignEdit = value; OnPropertyChanged(); }
    }

    private bool toWarehouseEdit;
    public bool ToWarehouseEdit
    {
        get => toWarehouseEdit;
        set { toWarehouseEdit = value; OnPropertyChanged(); }
    }

    private bool toReserveEdit;
    public bool ToReserveEdit
    {
        get => toReserveEdit;
        set { toReserveEdit = value; OnPropertyChanged(); }
    }

    #endregion

    #region Добавление

    private string? numberAdd;
    public string? NumberAdd
    {
        get => numberAdd;
        set { numberAdd = value; OnPropertyChanged(); }
    }

    private string? customerAdd;
    public string? CustomerAdd
    {
        get => customerAdd;
        set { customerAdd = value; OnPropertyChanged(); }
    }

    private DateTime? dateAdd;
    public DateTime? DateAdd
    {
        get => dateAdd;
        set { dateAdd = value; OnPropertyChanged(); }
    }

    private string? nameAdd;
    public string? NameAdd
    {
        get => nameAdd;
        set { nameAdd = value; OnPropertyChanged(); }
    }

    private string? commentAdd;
    public string? CommentAdd
    {
        get => commentAdd;
        set { commentAdd = value; OnPropertyChanged(); }
    }

    private string? priorityAdd;
    public string? PriorityAdd
    {
        get => priorityAdd;
        set { priorityAdd = value; OnPropertyChanged(); }
    }

    #endregion

    #endregion

    #endregion

    #region Команды

    public AsyncRelayCommand DataLoadingCommand => new(async () =>
    {
        await Task.Run(() =>
        {
            using DatabaseContext db = new();
            IsLoading = true;

            // Legacy request join v_request
            AllItems = new(
            from requests in db.Requests
            join tradeSigns in db.TradeSigns on new
            {
                requests.TradeSign
            } equals new
            {
                TradeSign = tradeSigns.TradeSign1
            }
            join viewRequests in db.VRequestForms on requests.RequestId equals viewRequests.RequestId
            orderby requests.RequestDate
            select new Request(viewRequests.RequestId,
                                viewRequests.RequestNum,
                                viewRequests.RequestDate,
                                viewRequests.RequestName,
                                viewRequests.Customer,
                                viewRequests.NameShort,
                                viewRequests.GroupMtr,
                                viewRequests.SupState,
                                viewRequests.Np,
                                viewRequests.Nl,
                                viewRequests.RequestComment,
                                viewRequests.Priority,
                                viewRequests.SumIncPrice,
                                viewRequests.PersonManager,
                                requests.TradeSign,
                                tradeSigns.TradeSignFullname,
                                requests.ToWarehouse,
                                requests.ToReserve));

            FilteredItems = AllItems;
        });
    });

    public RelayCommand ClearFilterCommand => new(() =>
    {
        NumberFilter = null;
        CustomerFilter = null;
        NameFilter = null;
        DirectioFilter = null;
        StatusFilter = null;
    });

    public AsyncRelayCommand DataFilteredCommand => new(async () =>
    {
        await Task.Run(() =>
        {
            if (AllItems == null)
            {
                DataLoadingCommand.Execute(null);
            }
            if (AllItems == null)
            {
                return;
            }

            IEnumerable<Request> filteredItems = AllItems.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(NumberFilter))
            {
                filteredItems = filteredItems.Where(x => x.RequestNum == NumberFilter);
            }
            if (!string.IsNullOrWhiteSpace(CustomerFilter))
            {
                filteredItems = filteredItems.Where(x => x.Customer == CustomerFilter);
            }
            if (!string.IsNullOrWhiteSpace(NameFilter))
            {
                filteredItems = filteredItems.Where(x => x.RequestName == NameFilter);
            }
            if (!string.IsNullOrWhiteSpace(DirectioFilter))
            {
                filteredItems = filteredItems.Where(x => x.PersonManager == DirectioFilter);
            }
            if (!string.IsNullOrWhiteSpace(StatusFilter))
            {
                filteredItems = filteredItems.Where(x => x.SupState == StatusFilter);
            }

            FilteredItems = new(filteredItems);
        });
    });

    public RelayCommand FillingEditFields => new(() =>
    {
        if (SelectedItems == null || SelectedItems.Count < 1)
        {
            return;
        }
        var selectedItem = SelectedItems[0];

        if (SelectedItems.Count == 1)
        {
            NumberEdit = selectedItem.RequestNum;
            NameEdit = selectedItem.RequestName;

            if (selectedItem.RequestDate != null)
            {
                DateEdit = selectedItem.RequestDate.ToDateTime();
            }
        }
        else
        {
            NumberEdit = null;
            NameEdit = null;
            DateEdit = null;
        }

        PriorityEdit = selectedItem.Priority;
        CommentEdit = selectedItem.RequestComment;
        CustomerEdit = selectedItem.Customer;
        DirectionEdit = selectedItem.PersonManager;
        TradeSignEdit = selectedItem.TradeSign;
        ToWarehouseEdit = selectedItem.ToWarehouse;
        ToReserveEdit = selectedItem.ToReserve;
    });

    public AsyncRelayCommand SaveDataCommand => new(async () =>
    {
        await Task.Run(() =>
        {
            if (SelectedItems == null || SelectedItems.Count == 0)
            {
                return;
            }

            using DatabaseContext db = new();
            foreach (var update in from selectedItem in SelectedItems
                                   let update = db.Requests.FirstOrDefault(r => r.RequestId == selectedItem.RequestId)
                                   select update)
            {
                if (update == null)
                {
                    return;
                }

                update.RequestComment = update.RequestComment.OldOrNew(CommentEdit);
                update.PersonManager = update.PersonManager.OldOrNew(DirectionEdit);
                update.ToWarehouse = update.ToWarehouse.OldOrNew(ToWarehouseEdit);
                update.ToReserve = update.ToReserve.OldOrNew(ToReserveEdit);
                update.Customer = update.Customer.OldOrNew(CustomerEdit);
                update.Priority = update.Priority.OldOrNew(PriorityEdit);
                update.TradeSign = update.TradeSign.OldOrNewNotNull(TradeSignEdit);

                if (SelectedItems.Count == 1)
                {
                    update.RequestNum = update.RequestNum.OldOrNew(NumberEdit);
                    update.RequestName = update.RequestName.OldOrNew(NameEdit);
                    update.ToReserve = update.ToReserve.OldOrNew(ToReserveEdit);
                    update.RequestDate = update.RequestDate.OldOrNew(DateEdit.ToDateOnly());

                }
            }

            db.SaveChanges();
            DataLoadingCommand.Execute(null);
        });
    });

    public RelayCommand ShowAddWindowCommnad => new(() =>
    {
        var dlg = new AddRequest()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner,
        };

        dlg.Show();
    });

    public AsyncRelayCommand AddCommnad => new(async () =>
    {
        await Task.Run(() =>
        {
            using DatabaseContext db = new();

            Models.Database.Request request = new()
            {
                RequestNum = NumberAdd,
                Customer = CustomerAdd,
                RequestDate = DateAdd.ToDateOnly(),
                RequestName = NameAdd,
                RequestComment = CommentAdd,
                Priority = PriorityAdd,
            };

            var asd = db.Requests.FirstOrDefault(x => x.RequestNum == request.RequestNum);
            if (asd == null)
            {
                db.Requests.Add(request);
            }
            else
            {
                // Feature оповещение что заявка уже существует
            }
            db.SaveChanges();

            DataFilteredCommand.Execute(null);
        });
    });

    public AsyncRelayCommand DeleteCommnad => new(async () =>
    {
        await Task.Run(() =>
        {
            using DatabaseContext db = new();

            foreach (var delete in from selectedItem in SelectedItems
                                   let delete = db.Requests.FirstOrDefault(request => request.RequestId == selectedItem.RequestId)
                                   where delete != null
                                   select delete)
            {
                db.Requests.Remove(delete);
            }

            db.SaveChanges();
            DataLoadingCommand.Execute(null);
        });
    });

    #endregion

    public ObservableCollection<string> PriorityItems { get; private set; }

    public ObservableCollection<string> CustomerItems { get; private set; }

    public ObservableCollection<string> DirectionItems { get; private set; }

    public ObservableCollection<string> StatusItems { get; private set; }

    public ObservableCollection<string> TradeSignItems { get; private set; }


    //public ObservableCollection<string> CustomerFilterItems { get; private set; }

    //public ObservableCollection<string> CustomerFilterItems { get; private set; }


    public RequestsViewModel()
    {

#pragma warning disable CS8620 // Аргумент запрещено использовать для параметра из-за различий в отношении допустимости значений NULL для ссылочных типов.
        using DatabaseContext db = new();

        IEnumerable<string?> priority = db.Requests
            .Select(r => r.Priority)
            .Where(r => !string.IsNullOrWhiteSpace(r))
            .Distinct();
        PriorityItems = new(priority);

        IEnumerable<string?> customer = db.Requests
            .Select(r => r.Customer)
            .Where(r => !string.IsNullOrWhiteSpace(r))
            .Distinct()
            .OrderBy(r => r);
        CustomerItems = new(customer);

        IEnumerable<string?> directionFilter = db.Requests
            .Select(r => r.PersonManager)
            .Where(r => !string.IsNullOrWhiteSpace(r))
            .Distinct()
            .OrderBy(r => r);
        DirectionItems = new(directionFilter);

        IEnumerable<string?> statusFilter = db.Requests
            .Select(r => r.RequestState)
            .Where(r => !string.IsNullOrWhiteSpace(r))
            .Distinct()
            .OrderBy(r => r);
        StatusItems = new(statusFilter);

        IEnumerable<string?> tradeSignItems = db.Requests
            .Select(r => r.TradeSign)
            .Where(r => !string.IsNullOrWhiteSpace(r))
            .Distinct()
            .OrderBy(r => r);
        TradeSignItems = new(tradeSignItems);
#pragma warning restore CS8620 // Аргумент запрещено использовать для параметра из-за различий в отношении допустимости значений NULL для ссылочных типов.
    }
}
