using BackofficeClient.Infrastructure.Extensions;
using BackofficeClient.Models.DataGrid;
using BackofficeClient.Models.Interfaces;
using BackofficeClient.Views.Windows;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BackofficeClient.ViewModels;

public class ProceduresViewModel : ViewModelBase, ILoadData, IDataGridCommand//, ICUFD, , ILoadComboBox
{
    #region Объекты для привязки

    #region Общие

    private ObservableCollection<Procedure> dataItems = [];
    private List<Procedure>? SelectedItems = [];

    public ObservableCollection<Procedure> DataItems
    {
        get => dataItems;
        set { dataItems = value; OnPropertyChanged(); }
    }

    #endregion

    #region Поиск

    private string? requestNumberFilter;
    private string? procedureName;
    private string? procedureGpb;
    private string? personFilter;
    private string? winnerFilter;
    private string? statusFilter;

    private bool? isDealRegistrationFilter;

    public string? RequestNumberFilter
    {
        get => requestNumberFilter;
        set { requestNumberFilter = value; OnPropertyChanged(); }
    }

    public string? ProcedureNameFilter
    {
        get => procedureName;
        set { procedureName = value; OnPropertyChanged(); }
    }

    public string? ProcedureGpbFilter
    {
        get => procedureGpb;
        set { procedureGpb = value; OnPropertyChanged(); }
    }

    public string? PersonFilter
    {
        get => personFilter;
        set { personFilter = value; OnPropertyChanged(); }
    }

    public string? WinnerFilter
    {
        get => winnerFilter;
        set { winnerFilter = value; OnPropertyChanged(); }
    }

    public string? StatusFilter
    {
        get => statusFilter;
        set { statusFilter = value; OnPropertyChanged(); }
    }

    public bool? IsDealRegistrationFilter
    {
        get => isDealRegistrationFilter;
        set { isDealRegistrationFilter = value; OnPropertyChanged(); }
    }

    #endregion

    #region Редактирование

    #region Одиночное

    private string? procedureNameEdit;
    private string? procedureGpb4Edit;
    private string? procedureGpbEdit;

    private DateTime? publicationDateEdit;
    private DateTime? tradingEndDateEdit;

    public string? ProcedureNameEdit
    {
        get => procedureNameEdit;
        set { procedureNameEdit = value; OnPropertyChanged(); }
    }

    public string? ProcedureGpb4Edit
    {
        get => procedureGpb4Edit;
        set { procedureGpb4Edit = value; OnPropertyChanged(); }
    }

    public string? ProcedureGpbEdit
    {
        get => procedureGpbEdit;
        set { procedureGpbEdit = value; OnPropertyChanged(); }
    }

    public DateTime? PublicationDateEdit
    {
        get => publicationDateEdit;
        set { publicationDateEdit = value; OnPropertyChanged(); }
    }

    public DateTime? TradingEndDateEdit
    {
        get => tradingEndDateEdit;
        set { tradingEndDateEdit = value; OnPropertyChanged(); }
    }

    #endregion

    #region Множественное
    private decimal? lotSumEdit;
    private decimal? lotSumNdsEdit;
    private string? statusEdit;
    private DateTime? dateEdit;


    public decimal? LotSumEdit
    {
        get => lotSumEdit;
        set { lotSumEdit = value; OnPropertyChanged(); }
    }

    public decimal? LotSumNdsEdit
    {
        get => lotSumNdsEdit;
        set { lotSumNdsEdit = value; OnPropertyChanged(); }
    }

    public string? StatusEdit
    {
        get => statusEdit;
        set { statusEdit = value; OnPropertyChanged(); }
    }

    public DateTime? DateEdit
    {
        get => dateEdit;
        set { dateEdit = value; OnPropertyChanged(); }
    }

    #endregion

    #endregion

    #region Добавление

    private string? procedureNameAdd;
    private string? procedureGpb4Add;
    private string? procedureGpbAdd;

    private DateTime? publicationDateAdd;
    private DateTime? tradingEndDateAdd;

    public string? ProcedureNameAdd
    {
        get => procedureNameAdd;
        set { procedureNameAdd = value; OnPropertyChanged(); }
    }

    public string? ProcedureGpb4Add
    {
        get => procedureGpb4Add;
        set { procedureGpb4Add = value; OnPropertyChanged(); }
    }

    public string? ProcedureGpbAdd
    {
        get => procedureGpbAdd;
        set { procedureGpbAdd = value; OnPropertyChanged(); }
    }

    public DateTime? PublicationDateAdd
    {
        get => publicationDateAdd;
        set { publicationDateAdd = value; OnPropertyChanged(); }
    }

    public DateTime? TradingEndDateAdd
    {
        get => tradingEndDateAdd;
        set { tradingEndDateAdd = value; OnPropertyChanged(); }
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
            DataItems = new(
            from vProcedures in db.VProcedures
            where string.IsNullOrWhiteSpace(RequestNumberFilter) || vProcedures.RequestNum == RequestNumberFilter
            where string.IsNullOrWhiteSpace(ProcedureNameFilter) || vProcedures.ProcedureName == ProcedureNameFilter
            where string.IsNullOrWhiteSpace(ProcedureGpbFilter) || vProcedures.ProcedureGpb == ProcedureGpbFilter
            where string.IsNullOrWhiteSpace(PersonFilter) || vProcedures.Person == PersonFilter
            where string.IsNullOrWhiteSpace(WinnerFilter) || vProcedures.SupName == WinnerFilter
            where string.IsNullOrWhiteSpace(StatusFilter) || vProcedures.SupState == StatusFilter
            where IsDealRegistrationFilter == null || (IsDealRegistrationFilter == true && vProcedures.DealDate != null) || (IsDealRegistrationFilter == false && vProcedures.DealDate == null)
            select new Procedure(vProcedures.Id,
            vProcedures.ProcedureGpb,
            vProcedures.ProcedureGpb4,
            vProcedures.RequestNum,
            vProcedures.ProcedureName,
            vProcedures.SupState,
            vProcedures.Nr,
            vProcedures.Np,
            vProcedures.Members,
            vProcedures.SupName,
            vProcedures.ProcedureDateEnd,
            vProcedures.ProcedureComment,
            vProcedures.Person,
            vProcedures.SumIncPrice,
            vProcedures.SumIncPriceNds,
            vProcedures.ProcedureDateBeg,
            vProcedures.DealDate,
            vProcedures.LastTkpLink,
            vProcedures.GroupMtr));
        });
    });

    public AsyncRelayCommand ClearFilterCommand => new(async () =>
    {
        await Task.Run(() =>
        {
            RequestNumberFilter = null;
            ProcedureNameFilter = null;
            ProcedureGpbFilter = null;
            PersonFilter = null;
            WinnerFilter = null;
            StatusFilter = null;
        });
    });

    #endregion

    #region DataGridCommand

    public AsyncRelayCommand<object> SelectDataCommand => new(async (parameter) =>
    {
        await Task.Run(() =>
        {
            SelectedItems = (parameter as System.Collections.IList)?.Cast<Procedure>().ToList();
            FillingFieldsCommand.Execute(null);
        });
    });

    #endregion

    #region CUFD

    public AsyncRelayCommand CreateDataCommand => new(async () =>
    {
        await Task.Run(() =>
        {
            if (ProcedureGpbAdd == null)
            {
                // Feature оповещение
                return;
            }

            using DatabaseContext db = new();

            // Legacy (net), Узнать когда создается
            Models.Database.Procedure create = new()
            {
                ProcedureName = ProcedureNameAdd,
                ProcedureGpb4 = ProcedureGpb4Add,
                ProcedureGpb = ProcedureGpbAdd,
                ProcedureDateBeg = PublicationDateAdd.ToDateOnly(),
                ProcedureDateEnd = TradingEndDateAdd.ToDateOnly(),
            };

            //var check = db.Procedures.FirstOrDefault(x => x.ProcedureId == create.id);
            //if (check == null)
            //{
            db.Procedures.Add(create);
            //}
            //else
            //{
            //    // Feature оповещение что заявка уже существует
            //}

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
            if (ProcedureGpbEdit == null || ProcedureGpb4Edit == null)
            {
                // Feature Сообщение что надо заполнить
                return;
            }

            using DatabaseContext db = new();
            foreach (var update in from selectedItem in SelectedItems
                                   let update = db.Procedures.FirstOrDefault(r => r.ProcedureId == selectedItem.Id)
                                   select update)
            {
                update.ProcedureGpb = ProcedureGpbEdit;
                update.ProcedureGpb = ProcedureGpb4Edit;
                update.ProcedureName = ProcedureNameEdit;
                update.ProcedureDateBeg = PublicationDateEdit.ToDateOnly();
                update.ProcedureDateEnd = TradingEndDateEdit.ToDateOnly();

                if (SelectedItems.Count == 1)
                {
                    update.SupState = StatusEdit;
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

            ProcedureGpbEdit = fill.ProcedureGpb;
            ProcedureGpb4Edit = fill.ProcedureGpb;
            ProcedureNameEdit = fill.ProcedureName;
            PublicationDateEdit = fill.ProcedureDateBeg.ToDateTime();
            TradingEndDateEdit = fill.ProcedureDateEnd.ToDateTime();

            if (SelectedItems.Count == 1)
            {
                LotSumEdit = fill.SumIncPrice;
                LotSumNdsEdit = fill.SumIncPriceNds;
                StatusEdit = fill.SupState;
            }
            else
            {
                LotSumEdit = null;
                LotSumNdsEdit = null;
                StatusEdit = null;
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
                                   let delete = db.Procedures.FirstOrDefault(procedures => procedures.ProcedureId == selectedItem.Id)
                                   where delete != null
                                   select delete)
            {
                db.Procedures.Remove(delete);
            }

            db.SaveChanges();
            LoadDataCommand.Execute(null);
        });
    });

    public RelayCommand ShowCreateWindowCommand => new(() =>
    {
        _ = new AddProcedure()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner,
        };
    });

    #endregion

    #endregion

}
