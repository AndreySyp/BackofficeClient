using CommunityToolkit.Mvvm.Input;

namespace BackofficeClient.Models.Interfaces;

public interface INterface1
{
    /// <summary>
    /// Заполнение полей редактирования
    /// </summary>
    public AsyncRelayCommand FillingEditFieldsCommand { get; }
    public AsyncRelayCommand<object> SelectDataCommand { get; }

    /// <summary>
    /// Сохранение изменений
    /// </summary>
    public AsyncRelayCommand SaveDataCommand { get; }

    /// <summary>
    /// Удаление данных
    /// </summary>
    public AsyncRelayCommand DeleteCommnad { get; }

    /// <summary>
    /// Очистка фильтров в поиске
    /// </summary>
    public AsyncRelayCommand ClearFilterCommand { get; }


    /// <summary>
    /// Добавление данных
    /// </summary>
    public AsyncRelayCommand AddCommnad { get; }

    /// <summary>
    /// Показать окно для добавления
    /// </summary>
    public RelayCommand ShowAddWindowCommnad { get; }
}
