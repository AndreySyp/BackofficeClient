using CommunityToolkit.Mvvm.Input;
using System.Windows.Controls;
using System.ComponentModel;
using static BackofficeClient.Infrastructure.Attributes;

namespace BackofficeClient.Infrastructure.Extensions;

public static class DataGridExtension
{
    public static RelayCommand<DataGridAutoGeneratingColumnEventArgs> GetDataGridSettingColumns()
    {
        return new((e) =>
        {
            if (e == null)
            {
                return;
            }

            if (e.PropertyDescriptor is PropertyDescriptor desc
                && desc.Attributes[typeof(ColumnNameAttribute)] is ColumnNameAttribute att)
            {
                e.Column.Header = att.Name;
            }
        });
    }
}
