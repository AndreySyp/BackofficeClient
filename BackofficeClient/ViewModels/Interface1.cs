using CommunityToolkit.Mvvm.Input;

namespace BackofficeClient.ViewModels;

public interface INterface1
{
    /// <summary>
    /// Заполнение полей редактирования
    /// </summary>
    public AsyncRelayCommand<object> FillingEditFields { get; }

    /// <summary>
    /// Сохранение изменений
    /// </summary>
    public AsyncRelayCommand<object> SaveDataCommand { get; }

    /// <summary>
    /// Удаление данных
    /// </summary>
    public AsyncRelayCommand<object> DeleteCommnad { get; }

    /// <summary>
    /// Показать окно для добавления
    /// </summary>
    public AsyncRelayCommand ShowAddWindowCommnad { get; }

    /// <summary>
    /// Очистка фильтров в поиске
    /// </summary>
    public AsyncRelayCommand ClearFilterCommand { get; }

    /// <summary>
    /// Загрузка данных
    /// </summary>
    public AsyncRelayCommand DataLoadingCommand { get; }

    /// <summary>
    /// Фильтрация данных в поиске
    /// </summary>
    public AsyncRelayCommand DataFilteredCommand { get; }

    /// <summary>
    /// Добавление данных
    /// </summary>
    public AsyncRelayCommand AddCommnad { get; }
}
