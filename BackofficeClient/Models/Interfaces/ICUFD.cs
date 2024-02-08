using CommunityToolkit.Mvvm.Input;

namespace BackofficeClient.Models.Interfaces;

interface ICUFD
{
    /// <summary>
    /// Добавление данных
    /// </summary>
    public AsyncRelayCommand CreateDataCommand { get; }

    /// <summary>
    /// Изменение данных
    /// </summary>
    public AsyncRelayCommand UpdateDataCommand { get; }

    /// <summary>
    /// Заполнение полей для изменения или добавления данных
    /// </summary>
    public AsyncRelayCommand FillingFieldsCommand { get; }

    /// <summary>
    /// Удаление данных
    /// </summary>
    public AsyncRelayCommand DeleteDataCommand { get; }

    /// <summary>
    /// Отображение окна для добавления
    /// </summary>
    public RelayCommand ShowCreateWindowCommand { get; }

}
