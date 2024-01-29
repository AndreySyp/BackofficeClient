using BackofficeClient.Models.DataGrid;
using System.ComponentModel;
using System.Windows.Controls;

namespace BackofficeClient.Views.MainWindowPages;

/// <summary>
/// Логика взаимодействия для Requests.xaml
/// </summary>
public partial class Requests : Page
{
    void dgPrimaryGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        PropertyDescriptor? desc = e.PropertyDescriptor as PropertyDescriptor;
        if (desc.Attributes[typeof(ColumnNameAttribute)] is ColumnNameAttribute att)
        {
            e.Column.Header = att.Name;
        }
    }
    public class ColumnNameAttribute : Attribute
    {
        public ColumnNameAttribute(string Name) { this.Name = Name; }
        public string Name { get; set; }
    }

    public Requests()
    {
        InitializeComponent();
        dgPrimaryGrid.AutoGeneratingColumn += dgPrimaryGrid_AutoGeneratingColumn;
    }
}
