namespace BackofficeClient.Models.Interfaces;

public interface ILoadComboBox
{
    /// <summary>
    /// Загрузка неизменяемых элементов в ComboBox
    /// </summary>
    public void ComboBoxStaticItemsLoad();

    /// <summary>
    /// Загрузка изменяемых элементов в ComboBox
    /// </summary>
    public void ComboBoxDynamicItemsLoad();
}
