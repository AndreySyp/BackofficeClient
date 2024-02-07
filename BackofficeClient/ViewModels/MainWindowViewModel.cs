using BackofficeClient.Models.Interfaces;
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
        set
        {
            _CurrentPage = value;

            if (_CurrentPage?.DataContext is ILoadData s)
            {
                s.LoadDataCommand.Execute(null);
            }

            OnPropertyChanged();
        }
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


    private bool isLoading = false;
    public bool IsLoading
    {
        get => isLoading;
        set { isLoading = value; OnPropertyChanged(); }
    }

    public RelayCommand LoadCommnad => new(() =>
    {
        if (CurrentPage?.DataContext is ILoadData s)
        {
            s.LoadDataCommand.Execute(null);
        }
    });

    public MainWindowViewModel()
    {

    }
}
