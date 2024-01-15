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

    private readonly Page p1 = new Requests();
    private readonly Page p2 = new Positions();

    public ICommand p1_c => new RelayCommand(() => CurrentPage = p1);
    public ICommand p2_c => new RelayCommand(() => CurrentPage = p2);
}
