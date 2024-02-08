using BackofficeClient.Models.Interfaces;
using BackofficeClient.Views.MainWindowPages;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Controls;

namespace BackofficeClient.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public Page? currentPage;
    public Page? CurrentPage
    {
        get => currentPage;
        set
        {
            currentPage = value;

            if (currentPage?.DataContext is ILoadData s)
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

    public RelayCommand PageRequestsClick => new(() => CurrentPage = pageRequests);

    public RelayCommand PagePositionsClick => new(() => CurrentPage = pagePositions);

    public RelayCommand PageProceduresClick => new(() => CurrentPage = pageProcedures);

    public RelayCommand PageAgreementConditionsClick => new(() => CurrentPage = pageAgreementConditions);

    public RelayCommand PageSpecificationsClick => new(() => CurrentPage = pageSpecifications);


    private bool isLoading = false;
    public bool IsLoading
    {
        get => isLoading;
        set { isLoading = value; OnPropertyChanged(); }
    }

    public RelayCommand LoadCommand => new(() =>
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
