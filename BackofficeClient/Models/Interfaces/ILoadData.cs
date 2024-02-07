using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BackofficeClient.Models.Interfaces;

interface ILoadData//<T>
{
    //abstract public ObservableCollection<T> DataItems { get; set; }

    /// <summary>
    /// Загрузка данных
    /// </summary>
    public AsyncRelayCommand LoadDataCommand { get; }

    /// <summary>
    /// Очистка фильтров в поиске
    /// </summary>
    public AsyncRelayCommand ClearFilterCommand { get; }
}
