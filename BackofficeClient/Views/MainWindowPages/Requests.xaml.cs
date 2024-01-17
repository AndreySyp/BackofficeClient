using System.Windows.Controls;

namespace BackofficeClient.Views.MainWindowPages;

/// <summary>
/// Логика взаимодействия для Requests.xaml
/// </summary>
public partial class Requests : Page
{
    public Requests()
    {
        InitializeComponent();

        using DatabaseContext db = new();
        var t1 = db.VRequestForms.ToList();
        var t2 = db.Requests.ToList();

        var c = t1.Join(t2,
            t1 => t1.RequestId,
            t2 => t2.RequestId,
            (t1, t2) => new { t1.RequestId, t1.RequestNum, t1.RequestDate, t1.RequestName, t1.Customer, t1.NameShort, t1.GroupMtr, t1.SupState, t1.Np, t1.Nl, t1.RequestComment, t1.Priority, t1.SumIncPrice, t1.PersonManager, t2.TradeSign}); 

        dataGrid.ItemsSource = c;
    }
}
