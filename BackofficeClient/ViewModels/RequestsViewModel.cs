using BackofficeClient.Infrastructure.Extensions;
using BackofficeClient.Models.DataGrid;
using BackofficeClient.Views.Windows;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BackofficeClient.ViewModels;

public class RequestsViewModel : ViewModelBase, INterface1
{

    #region Объекты для привязки

    #region Общие

    private ObservableCollection<Request> dataItems = [];
    public ObservableCollection<Request> DataItems
    {
        get => dataItems;
        set { dataItems = value; OnPropertyChanged(); }
    }

    private bool isLoading = false;
    public bool IsLoading
    {
        get => isLoading;
        set { isLoading = value; OnPropertyChanged(); }
    }

    #endregion

    #region Поиск

    private string? requestNumberFilter;
    public string? RequestNumberFilter
    {
        get => requestNumberFilter;
        set { requestNumberFilter = value; OnPropertyChanged(); }
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

    #region ComboBox

    public ObservableCollection<string>? PriorityItems { get; private set; }

    public ObservableCollection<string>? CustomerItems { get; private set; }

    public ObservableCollection<string>? DirectionItems { get; private set; }

    public ObservableCollection<string>? StatusItems { get; private set; }

    public ObservableCollection<string>? TradeSignItems { get; private set; }

    #endregion

    #endregion

    #region Команды
    public AsyncRelayCommand<object> FillingEditFields => new(async (parameter) =>
    {
        await Task.Run(() =>
        {
            var selectedItems = (parameter as System.Collections.IList)?.Cast<Request>().ToList();
            if (selectedItems == null || selectedItems.Count < 1)
            {
                return;
            }

            var selectedItem = selectedItems[0];
            if (selectedItems.Count == 1)
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
    });

    public AsyncRelayCommand<object> SaveDataCommand => new(async (parameter) =>
    {
        await Task.Run(() =>
        {
            var selectedItems = (parameter as System.Collections.IList)?.Cast<Request>().ToList();
            if (selectedItems == null || selectedItems.Count < 1)
            {
                return;
            }

            using DatabaseContext db = new();
            foreach (var update in from selectedItem in selectedItems
                                   let update = db.Requests.FirstOrDefault(r => r.RequestId == selectedItem.RequestId)
                                   select update)
            {
                if (update == null)
                {
                    return;
                }

                update.RequestComment = CommentEdit;
                update.PersonManager = DirectionEdit;
                update.ToWarehouse = ToWarehouseEdit;
                update.ToReserve = ToReserveEdit;
                update.Customer = CustomerEdit;
                update.Priority = PriorityEdit;
                update.TradeSign = TradeSignEdit;

                if (selectedItems.Count == 1)
                {
                    update.RequestNum = NumberEdit;
                    update.RequestName = NameEdit;
                    update.ToReserve = ToReserveEdit;
                    update.RequestDate = DateEdit.ToDateOnly();
                }
            }

            db.SaveChanges();
            DataLoadingCommand.Execute(null);
        });
    });

    public AsyncRelayCommand<object> DeleteCommnad => new(async (parameter) =>
    {
        await Task.Run(() =>
        {
            var selectedItems = (parameter as System.Collections.IList)?.Cast<Request>().ToList();
            if (selectedItems == null || selectedItems.Count < 1)
            {
                return;
            }

            using DatabaseContext db = new();
            foreach (var delete in from selectedItem in selectedItems
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

    public AsyncRelayCommand ClearFilterCommand => new(async () =>
    {
        await Task.Run(() =>
        {
            RequestNumberFilter = null;
            CustomerFilter = null;
            NameFilter = null;
            DirectioFilter = null;
            StatusFilter = null;
        });
    });

    public AsyncRelayCommand DataLoadingCommand => new(async () =>
    {
        await Task.Run(() =>
        {
            using DatabaseContext db = new();
            IsLoading = true;
            var c = RequestNumberFilter;

            // Legacy request join v_request
            DataItems = new(
            from requests in db.Requests
            join tradeSigns in db.TradeSigns on new
            {
                requests.TradeSign
            } equals new
            {
                TradeSign = tradeSigns.TradeSign1
            }
            join viewRequests in db.VRequestForms on requests.RequestId equals viewRequests.RequestId
            where string.IsNullOrWhiteSpace(RequestNumberFilter) || requests.RequestNum == RequestNumberFilter
            where string.IsNullOrWhiteSpace(CustomerFilter) || requests.Customer == CustomerFilter
            where string.IsNullOrWhiteSpace(NameFilter) || requests.RequestName == NameFilter
            where string.IsNullOrWhiteSpace(DirectioFilter) || requests.PersonManager == DirectioFilter
            where string.IsNullOrWhiteSpace(StatusFilter) || requests.SupState == StatusFilter
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
        });
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

            DataLoadingCommand.Execute(null);
        });
    });

    public RelayCommand ShowAddWindowCommnad => new(() =>
    {
        _ = new AddRequest()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner,
        };
    });

    #endregion

    public void LoadComboBoxItems()
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

    public RequestsViewModel()
    {
        LoadComboBoxItems();
    }
}
