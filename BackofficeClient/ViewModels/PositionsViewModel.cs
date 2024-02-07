using BackofficeClient.Models.DataGrid;
using BackofficeClient.Models.Interfaces;
using BackofficeClient.Views.MainWindowPages;
using BackofficeClient.Views.Windows;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BackofficeClient.ViewModels;

public class PositionsViewModel : ViewModelBase, ICUFD, IDataGridCommand, ILoadData//, INterface1
{

    #region Объекты для привязки

    public List<Position>? SelectedItems { get; set; } = [];

    private ObservableCollection<Position> dataItems = [];
    public ObservableCollection<Position> DataItems
    {
        get => dataItems;
        set { dataItems = value; OnPropertyChanged(); }
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

    #region CUFD

    public AsyncRelayCommand CreateDataCommnad => new(async () =>
    {
        await Task.Run(() =>
        {
            using DatabaseContext db = new();

            Models.Database.Request? request = db.Requests.FirstOrDefault(x => x.RequestNum == RequestNumberAdd);
            Models.Database.Position create = new()
            {
                RequestId = request?.RequestId,
                SupState = "Новая", // Legacy
                MtrName = MtrNameAdd,
                Amount = AmountAdd,
                Measure = MeasureAdd,

                RequestNum = RequestNumberAdd,
            };

            db.Positions.Add(create);

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
                                   let update = db.Positions.FirstOrDefault(r => r.PositionId.ToString() == selectedItem.PositionId)
                                   select update)
            {
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

                if (SelectedItems.Count == 1)
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

            GroupMtrEdit = fill.GroupMtr;
            ProcedureGpbEdit = fill.ProcedureGpb;
            WinnerEdit = fill.SupName;
            CurrencyEdit = fill.Currency;
            ResponsibleEdit = fill.Person;
            IncPriceEdit = fill.IncPrice;
            IncPriceNdsEdit = fill.IncPriceNds;
            IncPriceCurrencyEdit = fill.IncPriceCur;
            IncPriceNdsCurrencyEdit = fill.IncPriceCurNds;
            TimingEdit = fill.Timing;
            TimingMaxEdit = fill.TimingMax;

            if (SelectedItems.Count == 1)
            {
                NameMtrEdit = fill.MtrName;
                BasisEdit = fill.Basis;
                PositionNumberEdit = fill.PositionNum;
                DocNtdEdit = fill.DocNtd;
                AmountEdit = fill.Amount;
                MeasureEdit = fill.Measure;
                ManufacturerEdit = fill.Manufacturer;
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
        });
    });

    public AsyncRelayCommand DeleteDataCommnad => new(async () =>
    {
        await Task.Run(() =>
        {
            if (SelectedItems == null || SelectedItems.Count < 1)
            {
                return;
            }

            using DatabaseContext db = new();
            foreach (var delete in from selectedItem in SelectedItems
                                   let delete = db.Positions.FirstOrDefault(request => request.PositionId.ToString() == selectedItem.PositionId)
                                   where delete != null
                                   select delete)
            {
                db.Positions.Remove(delete);
            }

            db.SaveChanges();
            LoadDataCommand.Execute(null);
        });
    });

    public RelayCommand ShowCreateWindowCommnad => new(() =>
    {
        _ = new AddPosition()
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

            // LEGACY В одной таблице id инт в другой текст, что это ***********

            using DatabaseContext db = new();

            DataItems = new(
                    from position in db.Positions
                    join vPosition in db.VPositions on new
                    {
                        PositionId = position.PositionId.ToString()
                    } equals new
                    {
                        vPosition.PositionId
                    }
                    where string.IsNullOrWhiteSpace(RequestNumberFilter) || position.RequestNum == RequestNumberFilter
                    where string.IsNullOrWhiteSpace(PositionNumberFilter) || position.PositionNum == PositionNumberFilter
                    where string.IsNullOrWhiteSpace(ProcedureGpbFilter) || position.ProcedureGpb == ProcedureGpbFilter
                    where string.IsNullOrWhiteSpace(ResponsibleFilter) || position.Person == ResponsibleFilter
                    where string.IsNullOrWhiteSpace(NameMtrFilter) || position.MtrName == NameMtrFilter
                    where string.IsNullOrWhiteSpace(CurrencyFilter) || position.Currency == CurrencyFilter
                    where string.IsNullOrWhiteSpace(BasisFilter) || position.Basis == BasisFilter
                    where string.IsNullOrWhiteSpace(GroupMtrFilter) || position.GroupMtr == GroupMtrFilter
                    where string.IsNullOrWhiteSpace(WinnerFilter) || position.SupName == WinnerFilter
                    where string.IsNullOrWhiteSpace(StateFilter) || position.SupState == StateFilter
                    where string.IsNullOrWhiteSpace(LastChangeBeginFilter.ToString()) || position.UpdatedAt >= LastChangeBeginFilter
                    where string.IsNullOrWhiteSpace(LastChangeEndFilter.ToString()) || position.UpdatedAt <= LastChangeEndFilter
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

    #endregion

    #region DataGridCommand

    public AsyncRelayCommand<object> SelectDataCommand => new(async (parameter) =>
    {
        await Task.Run(() =>
        {
            SelectedItems = (parameter as System.Collections.IList)?.Cast<Position>().ToList();
            FillingFieldsCommand.Execute(null);
        });
    });

    #endregion

    #endregion

    public PositionsViewModel()
    {

    }
}
