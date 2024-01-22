using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BackofficeClient.ViewModels;

public class PositionsViewModel : ViewModelBase
{

    #region Объекты для привязки

    public ObservableCollection<object> AllItems { get; set; } = [];

    public ObservableCollection<object> SelectedItems { get; set; } = [];

    private ObservableCollection<object> filteredItems = [];
    public ObservableCollection<object> FilteredItems
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

    #endregion

    #region Команды

    public AsyncRelayCommand DataLoadingCommand => new(async () =>
    {
        await Task.Run(() =>
        {
            using DatabaseContext db = new();
            IsLoading = true;

            // LEGACY В одной таблице id инт в другой текст, что это ***********
            AllItems = new(db.VPositions.ToList().Join(
                    db.Positions.ToList(),
                    v => long.Parse(v.PositionId),
                    p => p.PositionId,
                    (v, p) => new { v.PositionId, v.RequestNum, v.RequestDate, v.PositionNum, v.MtrName, v.GroupMtr, v.DocNtd, v.Amount, v.Measure, v.DeliveryTime, v.Basis, v.Condition, v.Nmck, v.Currency, v.ProcedureGpb, v.ProcedureGpb4, v.SupState, v.Person, v.DateCustomerQuery, v.DateDocs, v.DateAgreement, v.DateAs, v.SupName, v.Timing, v.TimingMax, v.IncPrice, v.IncPriceNds, v.Manufacturer, v.IncPriceCur, v.IncPriceCurNds, v.ExchangeRate, v.OutPrice, v.OutPriceNds, v.OutPriceCur, v.OutPriceCurNds, p.UpdatedAt, p.SupObject })
                    .OrderBy(x => x.RequestNum)
                    .ThenBy(x => x.ProcedureGpb)
                    .ThenBy(x => x.PositionNum));

            FilteredItems = AllItems;
        });
    });

    public RelayCommand ClearFilterCommand => new(() =>
    {
        //RequestNumberFilter = null;
        //RequestCustomerFilter = null;
        //RequestNameFilter = null;
        //RequestDirectioFilter = null;
        //RequestStatusFilter = null;
    });

    public AsyncRelayCommand DataFilteredCommand => new(async () =>
    {
        //await Task.Run(() =>
        //{
        //    if (AllItems == null || AllItems.Count == 0)
        //    {
        //        DataLoadingCommand.Execute(null);
        //    }
        //    if (AllItems == null)
        //    {
        //        return;
        //    }

        //    IEnumerable<Request> filteredItems = AllItems.ToList();

        //    if (!string.IsNullOrWhiteSpace(RequestNumberFilter))
        //    {
        //        filteredItems = filteredItems.Where(x => x.RequestNum == RequestNumberFilter);
        //    }
        //    if (!string.IsNullOrWhiteSpace(RequestCustomerFilter))
        //    {
        //        filteredItems = filteredItems.Where(x => x.Customer == RequestCustomerFilter);
        //    }
        //    if (!string.IsNullOrWhiteSpace(RequestNameFilter))
        //    {
        //        filteredItems = filteredItems.Where(x => x.RequestName == RequestNameFilter);
        //    }
        //    if (!string.IsNullOrWhiteSpace(RequestDirectioFilter))
        //    {
        //        filteredItems = filteredItems.Where(x => x.PersonManager == RequestDirectioFilter);
        //    }
        //    if (!string.IsNullOrWhiteSpace(RequestStatusFilter))
        //    {
        //        filteredItems = filteredItems.Where(x => x.SupState == RequestStatusFilter);
        //    }

        //    FilteredItems = new(filteredItems);
        //});
    });

    public RelayCommand FillingEditFields => new(() =>
    {
        //if (SelectedItems == null)
        //{
        //    return;
        //}

        //if (SelectedItems.Count == 1)
        //{
        //    RequestNumberEdit = SelectedItems[0].RequestNum;
        //    RequestNameEdit = SelectedItems[0].RequestName;
        //    RequestDateEdit = SelectedItems[0].RequestDate;
        //}
        //else
        //{
        //    RequestNumberEdit = null;
        //    RequestNameEdit = null;
        //    RequestDateEdit = null;
        //}

        //RequestPriorityEdit = SelectedItems[0].Priority;
        //RequestCommentEdit = SelectedItems[0].RequestComment;
        //RequestCustomerEdit = SelectedItems[0].Customer;
        //RequestDirectionEdit = SelectedItems[0].PersonManager;
        //RequestTradeSignEdit = SelectedItems[0].TradeSign;
        //RequestToWarehouseEdit = SelectedItems[0].ToWarehouse;
        //RequestToReserveEdit = SelectedItems[0].ToReserve;
    });

    #endregion

    public PositionsViewModel()
    {

    }
}
