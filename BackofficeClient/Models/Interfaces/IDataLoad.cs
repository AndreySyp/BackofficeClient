using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BackofficeClient.Models.Interfaces;

interface IDataLoad//<T>
{
    //abstract public ObservableCollection<T> DataItems { get; set; }

    /// <summary>
    /// Загрузка данных
    /// </summary>
    public AsyncRelayCommand DataLoadingCommand { get; }
}
