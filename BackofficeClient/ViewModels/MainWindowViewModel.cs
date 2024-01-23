using BackofficeClient.Views.MainWindowPages;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Controls;
using System.Windows.Input;

namespace BackofficeClient.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public Page? _CurrentPage;
    public Page? CurrentPage
    {
        get => _CurrentPage;
        set { _CurrentPage = value; OnPropertyChanged(); }
    }

    private readonly Page pageRequests = new Requests();
    private readonly Page pagePositions = new Positions();
    private readonly Page pageProcedures = new Procedures();
    private readonly Page pageAgreementConditions = new AgreementConditions();
    private readonly Page pageSpecifications = new Specifications();

    public ICommand PageRequestsClick => new RelayCommand(() => CurrentPage = pageRequests);
    public ICommand PagePositionsClick => new RelayCommand(() => CurrentPage = pagePositions);
    public ICommand PageProceduresClick => new RelayCommand(() => CurrentPage = pageProcedures);
    public ICommand PageAgreementConditionsClick => new RelayCommand(() => CurrentPage = pageAgreementConditions);
    public ICommand PageSpecificationsClick => new RelayCommand(() => CurrentPage = pageSpecifications);

    public MainWindowViewModel()
    {

    }
}
