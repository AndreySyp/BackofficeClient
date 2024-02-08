using BackofficeClient.Infrastructure.Extensions;
using BackofficeClient.Models;
using BackofficeClient.Models.DataGrid;
using BackofficeClient.Models.Interfaces;
using BackofficeClient.Views.Windows;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BackofficeClient.ViewModels.PagesViewModels;

public class RequestsViewModel : ViewModelBase, ICUFD, IDataGridCommand, ILoadData, ILoadComboBox
{

    #region Объекты для привязки

    #region Общие

    private ObservableCollection<Request> dataItems = [];
    private List<Request>? SelectedItems = [];

    public ObservableCollection<Request> DataItems
    {
        get => dataItems;
        set { dataItems = value; OnPropertyChanged(); }
    }

    #endregion

    #region Поиск

    private string? requestNumberFilter;
    private string? customerFilter;
    private string? directionFilter;
    private string? statusFilter;
    private string? nameFilter;

    public string? RequestNumberFilter
    {
        get => requestNumberFilter;
        set { requestNumberFilter = value; OnPropertyChanged(); }
    }

    public string? CustomerFilter
    {
        get => customerFilter;
        set { customerFilter = value; OnPropertyChanged(); }
    }

    public string? DirectionFilter
    {
        get => directionFilter;
        set { directionFilter = value; OnPropertyChanged(); }
    }

    public string? StatusFilter
    {
        get => statusFilter;
        set { statusFilter = value; OnPropertyChanged(); }
    }

    public string? NameFilter
    {
        get => nameFilter;
        set { nameFilter = value; OnPropertyChanged(); }
    }

    #endregion

    #region Редактирование

    #region Одиночное

    private string? requestNumberEdit;
    private string? nameEdit;

    private DateTime? dateEdit;

    public string? RequestNumberEdit
    {
        get => requestNumberEdit;
        set { requestNumberEdit = value; OnPropertyChanged(); }
    }

    public string? NameEdit
    {
        get => nameEdit;
        set { nameEdit = value; OnPropertyChanged(); }
    }

    public DateTime? DateEdit
    {
        get => dateEdit;
        set { dateEdit = value; OnPropertyChanged(); }
    }

    #endregion

    #region Множественное

    private string? directionEdit;
    private string? tradeSignEdit;
    private string? priorityEdit;
    private string? customerEdit;
    private string? commentEdit;

    private bool toWarehouseEdit;
    private bool toReserveEdit;

    public string? DirectionEdit
    {
        get => directionEdit;
        set { directionEdit = value; OnPropertyChanged(); }
    }

    public string? TradeSignEdit
    {
        get => tradeSignEdit;
        set { tradeSignEdit = value; OnPropertyChanged(); }
    }

    public string? PriorityEdit
    {
        get => priorityEdit;
        set { priorityEdit = value; OnPropertyChanged(); }
    }

    public string? CustomerEdit
    {
        get => customerEdit;
        set { customerEdit = value; OnPropertyChanged(); }
    }

    public string? CommentEdit
    {
        get => commentEdit;
        set { commentEdit = value; OnPropertyChanged(); }
    }

    public bool ToWarehouseEdit
    {
        get => toWarehouseEdit;
        set { toWarehouseEdit = value; OnPropertyChanged(); }
    }

    public bool ToReserveEdit
    {
        get => toReserveEdit;
        set { toReserveEdit = value; OnPropertyChanged(); }
    }

    #endregion

    #endregion

    #region Добавление

    private string? requestNumberAdd;
    private string? customerAdd;
    private string? priorityAdd;
    private string? commentAdd;
    private string? nameAdd;

    private DateTime? dateAdd;

    public string? RequestNumberAdd
    {
        get => requestNumberAdd;
        set { requestNumberAdd = value; OnPropertyChanged(); }
    }

    public string? CustomerAdd
    {
        get => customerAdd;
        set { customerAdd = value; OnPropertyChanged(); }
    }

    public string? PriorityAdd
    {
        get => priorityAdd;
        set { priorityAdd = value; OnPropertyChanged(); }
    }

    public string? CommentAdd
    {
        get => commentAdd;
        set { commentAdd = value; OnPropertyChanged(); }
    }

    public string? NameAdd
    {
        get => nameAdd;
        set { nameAdd = value; OnPropertyChanged(); }
    }

    public DateTime? DateAdd
    {
        get => dateAdd;
        set { dateAdd = value; OnPropertyChanged(); }
    }

    #endregion

    #region ComboBox

    private ObservableCollection<string>? tradeSignItems;
    private ObservableCollection<string>? directionItems;
    private ObservableCollection<string>? priorityItems;
    private ObservableCollection<string>? customerItems;
    private ObservableCollection<string>? statusItems;

    public ObservableCollection<string>? TradeSignItems
    {
        get => tradeSignItems;
        private set { tradeSignItems = value; OnPropertyChanged(); }
    }

    public ObservableCollection<string>? DirectionItems
    {
        get => directionItems;
        private set { directionItems = value; OnPropertyChanged(); }
    }

    public ObservableCollection<string>? PriorityItems
    {
        get => priorityItems;
        private set { priorityItems = value; OnPropertyChanged(); }
    }

    public ObservableCollection<string>? CustomerItems
    {
        get => customerItems;
        private set { customerItems = value; OnPropertyChanged(); }
    }

    public ObservableCollection<string>? StatusItems
    {
        get => statusItems;
        private set { statusItems = value; OnPropertyChanged(); }
    }

    #endregion

    #endregion

    #region Команды

    #region CUFD

    public AsyncRelayCommand CreateDataCommand => new(async () =>
    {
        await Task.Run(() =>
        {
            using DatabaseContext db = new();

            Models.Database.Request create = new()
            {
                RequestNum = RequestNumberAdd,
                Customer = CustomerAdd,
                RequestDate = DateAdd.ToDateOnly(),
                RequestName = NameAdd,
                RequestComment = CommentAdd,
                Priority = PriorityAdd,
            };

            var check = db.Requests.FirstOrDefault(x => x.RequestNum == create.RequestNum);
            if (check == null)
            {
                db.Requests.Add(create);
            }
            else
            {
                // Feature оповещение что заявка уже существует
            }

            db.SaveChanges();
            LoadDataCommand.Execute(null);
        });
    });

    public AsyncRelayCommand UpdateDataCommand => new(async () =>
    {
        await Task.Run(() =>
        {
            if (SelectedItems == null || SelectedItems.Count < 1)
            {
                return;
            }

            using DatabaseContext db = new();
            foreach (var update in from selectedItem in SelectedItems
                                   let update = db.Requests.FirstOrDefault(r => r.RequestId == selectedItem.RequestId)
                                   select update)
            {
                update.RequestComment = CommentEdit;
                update.PersonManager = DirectionEdit;
                update.ToWarehouse = ToWarehouseEdit;
                update.ToReserve = ToReserveEdit;
                update.Customer = CustomerEdit;
                update.Priority = PriorityEdit;
                update.TradeSign = TradeSignEdit;

                if (SelectedItems.Count == 1)
                {
                    update.RequestNum = RequestNumberEdit;
                    update.RequestName = NameEdit;
                    update.ToReserve = ToReserveEdit;
                    update.RequestDate = DateEdit.ToDateOnly();
                }
            }

            db.SaveChanges();
            LoadDataCommand.Execute(null);
        });
    });

    public AsyncRelayCommand FillingFieldsCommand => new(async () =>
    {
        await Task.Run(() =>
        {
            if (SelectedItems == null || SelectedItems.Count < 1)
            {
                return;
            }

            var fill = SelectedItems[0];

            PriorityEdit = fill.Priority;
            CommentEdit = fill.RequestComment;
            CustomerEdit = fill.Customer;
            DirectionEdit = fill.PersonManager;
            TradeSignEdit = fill.TradeSign;
            ToWarehouseEdit = fill.ToWarehouse;
            ToReserveEdit = fill.ToReserve;

            if (SelectedItems.Count == 1)
            {
                RequestNumberEdit = fill.RequestNum;
                NameEdit = fill.RequestName;
                DateEdit = fill.RequestDate.ToDateTime();
            }
            else
            {
                RequestNumberEdit = null;
                NameEdit = null;
                DateEdit = null;
            }
        });
    });

    public AsyncRelayCommand DeleteDataCommand => new(async () =>
    {
        await Task.Run(() =>
        {
            if (SelectedItems == null || SelectedItems.Count < 1)
            {
                return;
            }

            using DatabaseContext db = new();
            foreach (var delete in from selectedItem in SelectedItems
                                   let delete = db.Requests.FirstOrDefault(request => request.RequestId == selectedItem.RequestId)
                                   where delete != null
                                   select delete)
            {
                db.Requests.Remove(delete);
            }

            db.SaveChanges();
            LoadDataCommand.Execute(null);
        });
    });

    public RelayCommand ShowCreateWindowCommand => new(() =>
    {
        _ = new AddRequest()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner,
        };
    });

    #endregion

    #region Load

    public AsyncRelayCommand LoadDataCommand => new(async () =>
    {
        await Task.Run(() =>
        {
            using DatabaseContext db = new();

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
            where string.IsNullOrWhiteSpace(DirectionFilter) || requests.PersonManager == DirectionFilter
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
            ;
        });
    });

    public AsyncRelayCommand ClearFilterCommand => new(async () =>
    {
        await Task.Run(() =>
        {
            RequestNumberFilter = null;
            CustomerFilter = null;
            NameFilter = null;
            DirectionFilter = null;
            StatusFilter = null;
        });
    });

    #endregion

    #region DataGridCommand

    public AsyncRelayCommand<object> SelectDataCommand => new(async (parameter) =>
    {
        await Task.Run(() =>
        {
            SelectedItems = (parameter as System.Collections.IList)?.Cast<Request>().ToList();
            FillingFieldsCommand.Execute(null);
        });
    });

    #endregion

    #endregion

    #region Функции

    #region ComboBoxLoad

    public async void ComboBoxStaticItemsLoad()
    {
        await Task.Run(() =>
        {
            PriorityItems = new(ComboBoxItems.PriorityItems);
            TradeSignItems = new(ComboBoxItems.TradeSignItems);
            DirectionItems = new(ComboBoxItems.DirectionItems);
            StatusItems = new(ComboBoxItems.CurrencyItems);
        });
    }

    public async void ComboBoxDynamicItemsLoad()
    {
        await Task.Run(() =>
        {
            using DatabaseContext db = new();
#pragma warning disable CS8619 // Допустимость значения NULL для ссылочных типов в значении не соответствует целевому типу.
            IEnumerable<string> customer = db.Requests
                .Select(r => r.Customer)
                .Where(p => !string.IsNullOrWhiteSpace(p))
                .Distinct()
                .OrderBy(r => r);
#pragma warning restore CS8619 // Допустимость значения NULL для ссылочных типов в значении не соответствует целевому типу.
            CustomerItems = new(customer);
        });
    }

    #endregion

    #endregion

    public RequestsViewModel()
    {
        ComboBoxStaticItemsLoad();
        ComboBoxDynamicItemsLoad();
    }
}
