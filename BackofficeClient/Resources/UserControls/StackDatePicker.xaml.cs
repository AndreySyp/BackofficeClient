using System.Windows;
using System.Windows.Controls;

namespace BackofficeClient.Resources.UserControls;

/// <summary>
/// Логика взаимодействия для StackDatePicker.xaml
/// </summary>
public partial class StackDatePicker : UserControl
{
    public static readonly DependencyProperty SelectedDateProperty =
    DependencyProperty.Register(
        "SelectedDate",
        typeof(DateTime?),
        typeof(StackDatePicker),
        new FrameworkPropertyMetadata(null,
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            new PropertyChangedCallback(OnSelectedDateChanged)));

    public string? Header { get; set; }

    public DateTime? SelectedDate
    {
        get { return (DateTime?)GetValue(SelectedDateProperty); }
        set { SetValue(SelectedDateProperty, value); }
    }

    public StackDatePicker()
    {
        InitializeComponent();
    }

    private static void OnSelectedDateChanged(DependencyObject @object, DependencyPropertyChangedEventArgs @event)
    {
        if (@object is not StackDatePicker control || @event.NewValue is not DateTime newValue)
        {
            return;
        }

        control.SelectedDate = newValue;
    }
}
