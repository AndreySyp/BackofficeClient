using BackofficeClient.Models.DataGrid;
using BackofficeClient.Models.Interfaces;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BackofficeClient.ViewModels;

class AgreementConditionsViewModel : ViewModelBase, ILoadData
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

    #endregion

    #region Команды

    #region Load

    public AsyncRelayCommand LoadDataCommand => new(async () =>
    {
        await Task.Run(() =>
        {
            using DatabaseContext db = new();

            // Legacy request join v_request
            //DataItems = new(
            //from vDeals in db.VDeals

            //join tradeSigns in db.TradeSigns on new
            //{
            //    requests.TradeSign
            //} equals new
            //{
            //    TradeSign = tradeSigns.TradeSign1
            //}
            //join viewRequests in db.VRequestForms on requests.RequestId equals viewRequests.RequestId
            ////where string.IsNullOrWhiteSpace(RequestNumberFilter) || requests.RequestNum == RequestNumberFilter
            ////where string.IsNullOrWhiteSpace(CustomerFilter) || requests.Customer == CustomerFilter
            ////where string.IsNullOrWhiteSpace(NameFilter) || requests.RequestName == NameFilter
            ////where string.IsNullOrWhiteSpace(DirectionFilter) || requests.PersonManager == DirectionFilter
            ////where string.IsNullOrWhiteSpace(StatusFilter) || requests.SupState == StatusFilter
            ////orderby requests.RequestDate
            //select new Request(viewRequests.RequestId,
            //                    viewRequests.RequestNum,
            //                    viewRequests.RequestDate,
            //                    viewRequests.RequestName,
            //                    viewRequests.Customer,
            //                    viewRequests.NameShort,
            //                    viewRequests.GroupMtr,
            //                    viewRequests.SupState,
            //                    viewRequests.Np,
            //                    viewRequests.Nl,
            //                    viewRequests.RequestComment,
            //                    viewRequests.Priority,
            //                    viewRequests.SumIncPrice,
            //                    viewRequests.PersonManager,
            //                    requests.TradeSign,
            //                    tradeSigns.TradeSignFullname,
            //                    requests.ToWarehouse,
            //                    requests.ToReserve));
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

    #endregion
}
