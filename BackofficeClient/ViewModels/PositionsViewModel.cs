using BackofficeClient.Models.DataGrid;
using BackofficeClient.Views.Windows;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BackofficeClient.ViewModels;

public class PositionsViewModel : ViewModelBase//, INterface1
{

    #region Объекты для привязки

    public ObservableCollection<Position> AllItems { get; set; } = [];

    public ObservableCollection<Position> SelectedItems { get; set; } = [];

    private ObservableCollection<Position> filteredItems = [];
    public ObservableCollection<Position> FilteredItems
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

    #region Поиск

    private string? requestNumberFilter;
    public string? RequestNumberFilter
    {
        get => requestNumberFilter;
        set { requestNumberFilter = value; OnPropertyChanged(); }
    }

    private string? positionNumberFilter;
    public string? PositionNumberFilter
    {
        get => positionNumberFilter;
        set { positionNumberFilter = value; OnPropertyChanged(); }
    }

    private string? procedureGpbFilter;
    public string? ProcedureGpbFilter
    {
        get => procedureGpbFilter;
        set { procedureGpbFilter = value; OnPropertyChanged(); }
    }

    private string? responsibleFilter;
    public string? ResponsibleFilter
    {
        get => responsibleFilter;
        set { responsibleFilter = value; OnPropertyChanged(); }
    }

    private string? nameMtrFilter;
    public string? NameMtrFilter
    {
        get => nameMtrFilter;
        set { nameMtrFilter = value; OnPropertyChanged(); }
    }

    private string? currencyFilter;
    public string? CurrencyFilter
    {
        get => currencyFilter;
        set { currencyFilter = value; OnPropertyChanged(); }
    }

    private string? basisFilter;
    public string? BasisFilter
    {
        get => basisFilter;
        set { basisFilter = value; OnPropertyChanged(); }
    }

    private string? groupMtrFilter;
    public string? GroupMtrFilter
    {
        get => groupMtrFilter;
        set { groupMtrFilter = value; OnPropertyChanged(); }
    }

    private string? winnerFilter;
    public string? WinnerFilter
    {
        get => winnerFilter;
        set { winnerFilter = value; OnPropertyChanged(); }
    }

    private string? stateFilter;
    public string? StateFilter
    {
        get => stateFilter;
        set { stateFilter = value; OnPropertyChanged(); }
    }

    private DateTime? lastChangeBeginFilter;
    public DateTime? LastChangeBeginFilter
    {
        get => lastChangeBeginFilter;
        set { lastChangeBeginFilter = value; OnPropertyChanged(); }
    }

    private DateTime? lastChangeEndFilter;
    public DateTime? LastChangeEndFilter
    {
        get => lastChangeEndFilter;
        set { lastChangeEndFilter = value; OnPropertyChanged(); }
    }

    #endregion

    #region Редактирование

    #region Одиночное

    private string? nameMtrEdit;
    public string? NameMtrEdit
    {
        get => nameMtrEdit;
        set { nameMtrEdit = value; OnPropertyChanged(); }
    }

    private string? basisEdit;
    public string? BasisEdit
    {
        get => basisEdit;
        set { basisEdit = value; OnPropertyChanged(); }
    }

    private string? positionNumberEdit;
    public string? PositionNumberEdit
    {
        get => positionNumberEdit;
        set { positionNumberEdit = value; OnPropertyChanged(); }
    }

    private string? docNtdEdit;
    public string? DocNtdEdit
    {
        get => docNtdEdit;
        set { docNtdEdit = value; OnPropertyChanged(); }
    }

    private decimal? amountEdit;
    public decimal? AmountEdit
    {
        get => amountEdit;
        set { amountEdit = value; OnPropertyChanged(); }
    }

    private string? measureEdit;
    public string? MeasureEdit
    {
        get => measureEdit;
        set { measureEdit = value; OnPropertyChanged(); }
    }

    private string? manufacturerEdit;
    public string? ManufacturerEdit
    {
        get => manufacturerEdit;
        set { manufacturerEdit = value; OnPropertyChanged(); }
    }
    #endregion

    #region Множественное

    private string? groupMtrEdit;
    public string? GroupMtrEdit
    {
        get => groupMtrEdit;
        set { groupMtrEdit = value; OnPropertyChanged(); }
    }

    private string? procedureGpbEdit;
    public string? ProcedureGpbEdit
    {
        get => procedureGpbEdit;
        set { procedureGpbEdit = value; OnPropertyChanged(); }
    }

    private string? winnerEdit;
    public string? WinnerEdit
    {
        get => winnerEdit;
        set { winnerEdit = value; OnPropertyChanged(); }
    }

    private string? currencyEdit;
    public string? CurrencyEdit
    {
        get => currencyEdit;
        set { currencyEdit = value; OnPropertyChanged(); }
    }

    private string? responsibleEdit;
    public string? ResponsibleEdit
    {
        get => responsibleEdit;
        set { responsibleEdit = value; OnPropertyChanged(); }
    }

    private string? timingEdit;
    public string? TimingEdit
    {
        get => timingEdit;
        set { timingEdit = value; OnPropertyChanged(); }
    }

    private int? timingMaxEdit;
    public int? TimingMaxEdit
    {
        get => timingMaxEdit;
        set { timingMaxEdit = value; OnPropertyChanged(); }
    }

    private decimal? incPriceEdit;
    public decimal? IncPriceEdit
    {
        get => incPriceEdit;
        set { incPriceEdit = value; OnPropertyChanged(); }
    }

    private decimal? incPriceNdsEdit;
    public decimal? IncPriceNdsEdit
    {
        get => incPriceNdsEdit;
        set { incPriceNdsEdit = value; OnPropertyChanged(); }
    }

    private decimal? incPriceCurrencyEdit;
    public decimal? IncPriceCurrencyEdit
    {
        get => incPriceCurrencyEdit;
        set { incPriceCurrencyEdit = value; OnPropertyChanged(); }
    }

    private decimal? incPriceNdsCurrencyEdit;
    public decimal? IncPriceNdsCurrencyEdit
    {
        get => incPriceNdsCurrencyEdit;
        set { incPriceNdsCurrencyEdit = value; OnPropertyChanged(); }
    }

    #endregion

    #endregion

    #region Добавление

    private string? requestAdd;
    public string? RequestNumberAdd
    {
        get => requestAdd;
        set { requestAdd = value; OnPropertyChanged(); }
    }

    private string? mtrNameAdd;
    public string? MtrNameAdd
    {
        get => mtrNameAdd;
        set { mtrNameAdd = value; OnPropertyChanged(); }
    }

    private int? amountAdd;
    public int? AmountAdd
    {
        get => amountAdd;
        set { amountAdd = value; OnPropertyChanged(); }
    }

    private string? measureAdd;
    public string? MeasureAdd
    {
        get => measureAdd;
        set { measureAdd = value; OnPropertyChanged(); }
    }

    #endregion

    #endregion

    #region Команды

    public AsyncRelayCommand<object> FillingEditFields => new(async (parameter) =>
    {
        await Task.Run(() =>
        {
            var selectedItems = (parameter as System.Collections.IList)?.Cast<Position>().ToList();
            if (selectedItems == null || selectedItems.Count < 1)
            {
                return;
            }

            var selectedItem = selectedItems[0];
            if (selectedItems.Count == 1)
            {
                NameMtrEdit = selectedItem.MtrName;
                BasisEdit = selectedItem.Basis;
                PositionNumberEdit = selectedItem.PositionNum;
                DocNtdEdit = selectedItem.DocNtd;
                AmountEdit = selectedItem.Amount;
                MeasureEdit = selectedItem.Measure;
                ManufacturerEdit = selectedItem.Manufacturer;
            }
            else
            {
                NameMtrEdit = null;
                BasisEdit = null;
                PositionNumberEdit = null;
                DocNtdEdit = null;
                AmountEdit = null;
                MeasureEdit = null;
                ManufacturerEdit = null;
            }

            GroupMtrEdit = selectedItem.GroupMtr;
            ProcedureGpbEdit = selectedItem.ProcedureGpb;
            WinnerEdit = selectedItem.SupName;
            CurrencyEdit = selectedItem.Currency;
            ResponsibleEdit = selectedItem.Person;
            IncPriceEdit = selectedItem.IncPrice;
            IncPriceNdsEdit = selectedItem.IncPriceNds;
            IncPriceCurrencyEdit = selectedItem.IncPriceCur;
            IncPriceNdsCurrencyEdit = selectedItem.IncPriceCurNds;
            TimingEdit = selectedItem.Timing;
            TimingMaxEdit = selectedItem.TimingMax;
        });
    });

    public AsyncRelayCommand<object> SaveDataCommand => new(async (parameter) =>
    {
        await Task.Run(() =>
        {
            var selectedItems = (parameter as System.Collections.IList)?.Cast<Position>().ToList();
            if (selectedItems == null || selectedItems.Count < 1)
            {
                return;
            }

            using DatabaseContext db = new();
            foreach (var update in from selectedItem in selectedItems
                                   let update = db.Positions.FirstOrDefault(r => r.PositionId.ToString() == selectedItem.PositionId)
                                   select update)
            {
                if (update == null)
                {
                    return;
                }

                update.Currency = CurrencyEdit ?? "RUB";
                update.GroupMtr = GroupMtrEdit;
                update.ProcedureGpb = ProcedureGpbEdit;
                update.SupName = WinnerEdit;
                update.Timing = TimingEdit;
                update.TimingMax = TimingMaxEdit;
                update.IncPrice = IncPriceEdit;
                update.IncPriceCur = IncPriceCurrencyEdit;
                update.IncPriceNds = IncPriceNdsEdit;
                update.IncPriceCurNds = IncPriceNdsCurrencyEdit;
                update.Person = ResponsibleEdit;

                if (selectedItems.Count == 1)
                {
                    update.MtrName = NameMtrEdit;
                    update.DocNtd = DocNtdEdit;
                    update.Amount = AmountEdit;
                    update.Measure = MeasureEdit;
                    update.Basis = BasisEdit;
                    update.PositionNum = PositionNumberEdit;
                    update.Manufacturer = ManufacturerEdit;
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
            var selectedItems = (parameter as System.Collections.IList)?.Cast<Position>().ToList();
            if (selectedItems == null || selectedItems.Count < 1)
            {
                return;
            }

            using DatabaseContext db = new();
            foreach (var delete in from selectedItem in selectedItems
                                   let delete = db.Positions.FirstOrDefault(request => request.PositionId.ToString() == selectedItem.PositionId)
                                   where delete != null
                                   select delete)
            {
                db.Positions.Remove(delete);
            }

            db.SaveChanges();
            DataLoadingCommand.Execute(null);
        });
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

            IEnumerable<Position> filteredItems = AllItems.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(RequestNumberFilter))
            {
                filteredItems = filteredItems.Where(x => x.RequestNum == RequestNumberFilter);
            }
            if (!string.IsNullOrWhiteSpace(PositionNumberFilter))
            {
                filteredItems = filteredItems.Where(x => x.PositionNum == PositionNumberFilter);
            }
            if (!string.IsNullOrWhiteSpace(ProcedureGpbFilter))
            {
                filteredItems = filteredItems.Where(x => x.ProcedureGpb == ProcedureGpbFilter);
            }
            if (!string.IsNullOrWhiteSpace(ResponsibleFilter))
            {
                filteredItems = filteredItems.Where(x => x.Person == ResponsibleFilter);
            }
            if (!string.IsNullOrWhiteSpace(NameMtrFilter))
            {
                filteredItems = filteredItems.Where(x => x.MtrName == NameMtrFilter);
            }
            if (!string.IsNullOrWhiteSpace(CurrencyFilter))
            {
                filteredItems = filteredItems.Where(x => x.Currency == CurrencyFilter);
            }
            if (!string.IsNullOrWhiteSpace(BasisFilter))
            {
                filteredItems = filteredItems.Where(x => x.Basis == BasisFilter);
            }
            if (!string.IsNullOrWhiteSpace(GroupMtrFilter))
            {
                filteredItems = filteredItems.Where(x => x.GroupMtr == GroupMtrFilter);
            }
            if (!string.IsNullOrWhiteSpace(WinnerFilter))
            {
                filteredItems = filteredItems.Where(x => x.SupName == WinnerFilter);
            }
            if (!string.IsNullOrWhiteSpace(StateFilter))
            {
                filteredItems = filteredItems.Where(x => x.SupState == StateFilter);
            }
            if (!string.IsNullOrWhiteSpace(LastChangeBeginFilter.ToString()))
            {
                filteredItems = filteredItems.Where(x => x.UpdatedAt >= LastChangeBeginFilter);
            }
            if (!string.IsNullOrWhiteSpace(LastChangeEndFilter.ToString()))
            {
                filteredItems = filteredItems.Where(x => x.UpdatedAt <= LastChangeEndFilter);
            }

            FilteredItems = new(filteredItems);
        });
    });

    public AsyncRelayCommand ClearFilterCommand => new(async () =>
    {
        await Task.Run(() =>
        {
            RequestNumberFilter = null;
            PositionNumberFilter = null;
            ProcedureGpbFilter = null;
            ResponsibleFilter = null;
            NameMtrFilter = null;
            CurrencyFilter = null;
            BasisFilter = null;
            GroupMtrFilter = null;
            WinnerFilter = null;
            StateFilter = null;
            LastChangeBeginFilter = null;
            LastChangeEndFilter = null;
        });
    });

    public AsyncRelayCommand DataLoadingCommand => new(async () =>
    {
        await Task.Run(() =>
        {
            using DatabaseContext db = new();
            IsLoading = true;

            // LEGACY В одной таблице id инт в другой текст, что это ***********

            AllItems = new(
                from position in db.Positions
                join vPosition in db.VPositions on new
                {
                    PositionId = position.PositionId.ToString()
                } equals new
                {
                    vPosition.PositionId
                }
                orderby vPosition.RequestNum, vPosition.ProcedureGpb, vPosition.PositionNum
                select new Position(vPosition.PositionId,
                                    vPosition.RequestNum,
                                    vPosition.RequestDate,
                                    vPosition.PositionNum,
                                    vPosition.MtrName,
                                    vPosition.GroupMtr,
                                    vPosition.DocNtd,
                                    vPosition.Amount,
                                    vPosition.Measure,
                                    vPosition.DeliveryTime,
                                    vPosition.Basis,
                                    vPosition.Condition,
                                    vPosition.Nmck,
                                    vPosition.Currency,
                                    vPosition.ProcedureGpb,
                                    vPosition.ProcedureGpb4,
                                    vPosition.SupState,
                                    vPosition.Person,
                                    vPosition.DateCustomerQuery,
                                    vPosition.DateDocs,
                                    vPosition.DateAgreement,
                                    vPosition.DateAs,
                                    vPosition.SupName,
                                    vPosition.Timing,
                                    vPosition.TimingMax,
                                    vPosition.IncPrice,
                                    vPosition.IncPriceNds,
                                    vPosition.Manufacturer,
                                    vPosition.IncPriceCur,
                                    vPosition.IncPriceCurNds,
                                    vPosition.ExchangeRate,
                                    vPosition.OutPrice,
                                    vPosition.OutPriceNds,
                                    vPosition.OutPriceCur,
                                    vPosition.OutPriceCurNds,
                                    position.UpdatedAt,
                                    position.SupObject));

            FilteredItems = AllItems;
        });
    });

    public AsyncRelayCommand AddCommnad => new(async () =>
    {
        await Task.Run(() =>
        {
            using DatabaseContext db = new();

            Models.Database.Position add = new()
            {
                RequestNum = RequestNumberAdd,
                MtrName = MtrNameAdd,
                Amount = AmountAdd,
                Measure = MeasureAdd,
            };

            var asd = db.Positions.FirstOrDefault(x => x.RequestNum == add.RequestNum);
            if (asd == null)
            {
                db.Positions.Add(add);
            }
            else
            {
                // Feature оповещение что заявка уже существует
            }
            db.SaveChanges();

            DataFilteredCommand.Execute(null);
        });
    });

    public RelayCommand ShowAddWindowCommnad => new(() =>
    {
        _ = new AddPosition()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner,
        };
    });

    #endregion

    public PositionsViewModel()
    {

    }
}
