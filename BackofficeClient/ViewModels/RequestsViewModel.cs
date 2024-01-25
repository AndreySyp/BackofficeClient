using BackofficeClient.Models.DataGrid;
using BackofficeClient.Views.Windows;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;

namespace BackofficeClient.ViewModels;

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

    private DateOnly? dateEdit;
    public DateOnly? DateEdit
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

    private bool? toWarehouseEdit;
    public bool? ToWarehouseEdit
    {
        get => toWarehouseEdit;
        set { toWarehouseEdit = value; OnPropertyChanged(); }
    }

    private bool? toReserveEdit;
    public bool? ToReserveEdit
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

    private DateOnly? dateAdd;
    public DateOnly? DateAdd
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
            DataLoadingCommand.Execute(null);
            if (AllItems == null)
            {
                return;
            }

            IEnumerable<Request> filteredItems = AllItems.ToList();

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

        if (SelectedItems.Count == 1)
        {
            NumberEdit = SelectedItems[0].RequestNum;
            NameEdit = SelectedItems[0].RequestName;
            DateEdit = SelectedItems[0].RequestDate;
        }
        else
        {
            NumberEdit = null;
            NameEdit = null;
            DateEdit = null;
        }

        PriorityEdit = SelectedItems[0].Priority;
        CommentEdit = SelectedItems[0].RequestComment;
        CustomerEdit = SelectedItems[0].Customer;
        DirectionEdit = SelectedItems[0].PersonManager;
        TradeSignEdit = SelectedItems[0].TradeSign;
        ToWarehouseEdit = SelectedItems[0].ToWarehouse;
        ToReserveEdit = SelectedItems[0].ToReserve;
    });

    public AsyncRelayCommand SaveDataCommand => new(async () =>
    {
        if (SelectedItems == null || SelectedItems.Count == 0)
        {
            return;
        }

        await Task.Run(() =>
        {
            using DatabaseContext db = new();
            var c = db.Requests;

            foreach (var item in SelectedItems)
            {
                var c1 = c.Where(c => c.RequestId == item.RequestId).FirstOrDefault();

                
                if (c1 == null)
                {
                    
                    return;
                }

                c1.Priority = PriorityEdit;
                c1.RequestComment = CommentEdit;
                c1.Customer = CustomerEdit;
                c1.PersonManager = DirectionEdit;
                c1.TradeSign = TradeSignEdit;
                c1.ToWarehouse = ToWarehouseEdit ?? false;
                c1.ToReserve = ToReserveEdit ?? false;

                if (SelectedItems.Count == 1)
                {
                    continue;
                }

                c1.RequestNum =NumberEdit;
                c1.RequestName = NameEdit;
                c1.RequestDate = DateEdit;
            }

            db.SaveChanges();
        });

        DataLoadingCommand.Execute(null);
    });

    public RelayCommand ShowAddRequestWindowCommnad => new(() =>
    {
        var dlg = new AddRequest()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner,
        };

        dlg.Show();
    });

    public AsyncRelayCommand AddRequestCommnad => new(async () =>
    {
        await Task.Run(() =>
        {
            using DatabaseContext db = new();

            Models.Database.Request request = new()
            {
                RequestNum = NumberAdd,
                Customer = CustomerAdd,
                RequestDate = DateAdd,
                RequestName = NameAdd,
                RequestComment = CommentAdd,
                Priority = PriorityAdd,
            };

            db.Requests.Add(request);
            db.SaveChanges();

            DataFilteredCommand.Execute(null);
        });
    });

    public AsyncRelayCommand DeleteRequestCommnad => new(async () =>
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

    public RequestsViewModel()
    {
    }
}
