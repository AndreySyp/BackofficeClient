using CommunityToolkit.Mvvm.Input;

namespace BackofficeClient.Models.Interfaces;

public interface IDataGridCommand
{
    /// <summary>
    /// Действия при выборе данных
    /// </summary>
    public AsyncRelayCommand<object> SelectDataCommand { get; }
}
