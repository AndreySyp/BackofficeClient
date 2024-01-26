using CommunityToolkit.Mvvm.Input;

namespace BackofficeClient.ViewModels;

public interface INterface1
{
    /// <summary>
    /// Загрузка данных
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

    /// <summary>
    /// Сохранение изменений
    /// </summary>
    public AsyncRelayCommand SaveDataCommand { get; }

    /// <summary>
    /// Показать окно для добавления
    /// </summary>
    public RelayCommand ShowAddWindowCommnad { get; }

    /// <summary>
    /// Добавление данных
    /// </summary>
    public AsyncRelayCommand AddCommnad { get; }

    /// <summary>
    /// Удаление данных
    /// </summary>
    public AsyncRelayCommand DeleteCommnad { get; }
}
