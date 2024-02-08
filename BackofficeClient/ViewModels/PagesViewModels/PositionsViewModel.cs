using BackofficeClient.Models;
using BackofficeClient.Models.DataGrid;
using BackofficeClient.Models.Interfaces;
using BackofficeClient.Views.Windows;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BackofficeClient.ViewModels.PagesViewModels;

public class PositionsViewModel : ViewModelBase, ICUFD, IDataGridCommand, ILoadData, ILoadComboBox
{

    #region Объекты для привязки

    #region Общие

    private ObservableCollection<Position> dataItems = [];
    private List<Position>? SelectedItems = [];

    public ObservableCollection<Position> DataItems
    {
        get => dataItems;
        set { dataItems = value; OnPropertyChanged(); }
    }

    #endregion

    #region Поиск

    private string? positionNumberFilter;
    private string? requestNumberFilter;
    private string? procedureGpbFilter;
    private string? responsibleFilter;
    private string? currencyFilter;
    private string? groupMtrFilter;
    private string? nameMtrFilter;
    private string? winnerFilter;
    private string? basisFilter;
    private string? stateFilter;

    private DateTime? lastChangeEndFilter;
    private DateTime? lastChangeBeginFilter;

    public string? PositionNumberFilter
    {
        get => positionNumberFilter;
        set { positionNumberFilter = value; OnPropertyChanged(); }
    }

    public string? RequestNumberFilter
    {
        get => requestNumberFilter;
        set { requestNumberFilter = value; OnPropertyChanged(); }
    }

    public string? ProcedureGpbFilter
    {
        get => procedureGpbFilter;
        set { procedureGpbFilter = value; OnPropertyChanged(); }
    }

    public string? ResponsibleFilter
    {
        get => responsibleFilter;
        set { responsibleFilter = value; OnPropertyChanged(); }
    }

    public string? CurrencyFilter
    {
        get => currencyFilter;
        set { currencyFilter = value; OnPropertyChanged(); }
    }

    public string? GroupMtrFilter
    {
        get => groupMtrFilter;
        set { groupMtrFilter = value; OnPropertyChanged(); }
    }

    public string? NameMtrFilter
    {
        get => nameMtrFilter;
        set { nameMtrFilter = value; OnPropertyChanged(); }
    }

    public string? WinnerFilter
    {
        get => winnerFilter;
        set { winnerFilter = value; OnPropertyChanged(); }
    }

    public string? BasisFilter
    {
        get => basisFilter;
        set { basisFilter = value; OnPropertyChanged(); }
    }

    public string? StateFilter
    {
        get => stateFilter;
        set { stateFilter = value; OnPropertyChanged(); }
    }

    public DateTime? LastChangeEndFilter
    {
        get => lastChangeEndFilter;
        set { lastChangeEndFilter = value; OnPropertyChanged(); }
    }

    public DateTime? LastChangeBeginFilter
    {
        get => lastChangeBeginFilter;
        set { lastChangeBeginFilter = value; OnPropertyChanged(); }
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

    private string? requestNumberAdd;
    private string? mtrNameAdd;
    private string? measureAdd;

    private int? amountAdd;

    public string? RequestNumberAdd
    {
        get => requestNumberAdd;
        set { requestNumberAdd = value; OnPropertyChanged(); }
    }

    public string? MtrNameAdd
    {
        get => mtrNameAdd;
        set { mtrNameAdd = value; OnPropertyChanged(); }
    }

    public string? MeasureAdd
    {
        get => measureAdd;
        set { measureAdd = value; OnPropertyChanged(); }
    }

    public int? AmountAdd
    {
        get => amountAdd;
        set { amountAdd = value; OnPropertyChanged(); }
    }

    #endregion

    #region ComboBox

    private ObservableCollection<string>? requestNumberItems;
    private ObservableCollection<string>? procedureGpbItems;
    private ObservableCollection<string>? groupMtrItems;
    private ObservableCollection<string>? currencyItems;
    private ObservableCollection<string>? measureItems;
    private ObservableCollection<string>? winnerItems;
    private ObservableCollection<string>? statusItems;
    private ObservableCollection<string>? personItems;

    public ObservableCollection<string>? RequestNumberItems
    {
        get => requestNumberItems;
        private set { requestNumberItems = value; OnPropertyChanged(); }
    }

    public ObservableCollection<string>? ProcedureGpbItems
    {
        get => procedureGpbItems;
        private set { procedureGpbItems = value; OnPropertyChanged(); }
    }

    public ObservableCollection<string>? GroupMtrItems
    {
        get => groupMtrItems;
        private set { groupMtrItems = value; OnPropertyChanged(); }
    }

    public ObservableCollection<string>? CurrencyItems
    {
        get => currencyItems;
        private set { currencyItems = value; OnPropertyChanged(); }
    }

    public ObservableCollection<string>? WinnerItems
    {
        get => winnerItems;
        private set { winnerItems = value; OnPropertyChanged(); }
    }

    public ObservableCollection<string>? MeasureItems
    {
        get => measureItems;
        private set { measureItems = value; OnPropertyChanged(); }
    }

    public ObservableCollection<string>? StatusItems
    {
        get => statusItems;
        private set { statusItems = value; OnPropertyChanged(); }
    }

    public ObservableCollection<string>? PersonItems
    {
        get => personItems;
        private set { personItems = value; OnPropertyChanged(); }
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

    public RelayCommand ShowCreateWindowCommand => new(() =>
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

    #region Функции

    public async void ComboBoxStaticItemsLoad()
    {
        await Task.Run(() =>
        {
            StatusItems = new(ComboBoxItems.StatusItems);
            CurrencyItems = new(ComboBoxItems.CurrencyItems);
            PersonItems = new(ComboBoxItems.PersonItems);
            MeasureItems = new(ComboBoxItems.MeasureItems);
        });
    }

    public async void ComboBoxDynamicItemsLoad()
    {
        await Task.Run(() =>
        {
            using DatabaseContext db = new();
#pragma warning disable CS8619 // Допустимость значения NULL для ссылочных типов в значении не соответствует целевому типу.
            IEnumerable<string> procedureGpbItems = db.Positions
                .Select(r => r.ProcedureGpb)
                .Where(p => !string.IsNullOrWhiteSpace(p))
                .Distinct()
                .OrderBy(r => r);

            IEnumerable<string> groupMtrItems = db.Positions
                .Select(r => r.GroupMtr)
                .Where(p => !string.IsNullOrWhiteSpace(p))
                .Distinct()
                .OrderBy(r => r);

            IEnumerable<string> winnerItems = db.Positions
                .Select(r => r.SupName)
                .Where(p => !string.IsNullOrWhiteSpace(p))
                .Distinct()
                .OrderBy(r => r);

            IEnumerable<string> requestNumberItems = db.Positions
                .Select(r => r.RequestNum)
                .Where(p => !string.IsNullOrWhiteSpace(p))
                .Distinct()
                .OrderBy(r => r);
#pragma warning restore CS8619 // Допустимость значения NULL для ссылочных типов в значении не соответствует целевому типу.
            ProcedureGpbItems = new(procedureGpbItems);
            GroupMtrItems = new(groupMtrItems);
            WinnerItems = new(winnerItems);
            RequestNumberItems = new(requestNumberItems);
        });
    }

    #endregion

    public PositionsViewModel()
    {
        ComboBoxStaticItemsLoad();
        ComboBoxDynamicItemsLoad();
    }
}
