using BackofficeClient.Models;
using System.Windows;

namespace BackofficeClient;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{

    public static void FillStaticComboBox()
    {
        System.Linq.Expressions.Expression<Func<string?, bool>> predicate = p => !string.IsNullOrWhiteSpace(p);
        using DatabaseContext db = new();

        // Legacy Надо брать из табличек где не может быть NULL
#pragma warning disable CS8619 // Допустимость значения NULL для ссылочных типов в значении не соответствует целевому типу.
        ComboBoxItems.PriorityItems = db.Requests
            .Select(r => r.Priority)
            .Where(predicate)
            .Distinct()
            .OrderBy(r => r)
            .ToList();


        ComboBoxItems.TradeSignItems = db.Requests
            .Select(r => r.TradeSign)
            .Where(predicate)
            .Distinct()
            .OrderBy(r => r)
            .ToList();

        ComboBoxItems.DirectionItems = db.Requests
            .Select(r => r.PersonManager)
            .Where(predicate)
            .Distinct()
            .OrderBy(r => r)
            .ToList();

        ComboBoxItems.StatusItems = db.Requests
            .Select(r => r.RequestState)
            .Where(predicate)
            .Distinct()
            .OrderBy(r => r)
            .ToList();

        ComboBoxItems.CurrencyItems = db.Positions
            .Select(r => r.Currency)
            .Where(predicate)
            .Distinct()
            .OrderBy(r => r)
            .ToList();

        ComboBoxItems.PersonItems = db.Positions
            .Select(r => r.Person)
            .Where(predicate)
            .Distinct()
            .OrderBy(r => r)
            .ToList();

        ComboBoxItems.MeasureItems = db.Positions
            .Select(r => r.Measure)
            .Where(predicate)
            .Distinct()
            .OrderBy(r => r)
            .ToList();
#pragma warning restore CS8619 // Допустимость значения NULL для ссылочных типов в значении не соответствует целевому типу.
    }

    private void App_Startup(object sender, StartupEventArgs e)
    {
        FillStaticComboBox();
    }
}
