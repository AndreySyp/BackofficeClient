using BackofficeClient.Infrastructure;
using BackofficeClient.Views.MainWindowPages;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Controls;
using System.Windows.Input;

namespace BackofficeClient.ViewModels;

public class MainWindowViewModel : ViewModel
{
    public Page _CurrentPage;
    public Page CurrentPage
    {
        get => _CurrentPage;
        set { _CurrentPage = value; OnPropertyChanged(); }
    }

    private readonly Page pageRequests = new Requests();
    private readonly Page pagePositions = new Positions();

    public ICommand PageRequestsClick => new RelayCommand(() => CurrentPage = pageRequests);
    public ICommand PagePositionsClick => new RelayCommand(() => CurrentPage = pagePositions);

    public MainWindowViewModel()
    {
        SQLWorker.ConconnectionSQl = "Server=localhost; Port=5432; User Id=postgres; Database=request_report; ApplicationName = 'BackOfficeDBClient'; Password=1111;";
    }
}
