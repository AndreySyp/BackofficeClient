using CommunityToolkit.Mvvm.Input;

namespace BackofficeClient.ViewModels;

public interface INterface1
{
    /// <summary>
    /// Загрузка и отображение данных
    /// </summary>
    public AsyncRelayCommand DataLoadingCommand { get; }

    /// <summary>
    /// Очистка фильтров в поиске
    /// </summary>
    public RelayCommand ClearFilterCommand { get; }

    /// <summary>
    /// Фильтрация данных в поиске
    /// </summary>
    public AsyncRelayCommand DataFilteredCommand { get; }

    /// <summary>
    /// Заполнение полей редактирования
    /// </summary>
    public RelayCommand FillingEditFields { get; }
}
