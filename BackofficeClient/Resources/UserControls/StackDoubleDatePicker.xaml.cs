using System.Windows;
using System.Windows.Controls;

namespace BackofficeClient.Resources.UserControls;

/// <summary>
/// Логика взаимодействия для StackDoubleDatePicker.xaml
/// </summary>
public partial class StackDoubleDatePicker : UserControl
{
    public static readonly DependencyProperty SelectedDateStartProperty =
    DependencyProperty.Register(
        "SelectedDateStart",
        typeof(DateTime?),
        typeof(StackDoubleDatePicker),
        new FrameworkPropertyMetadata(null,
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            new PropertyChangedCallback(OnSelectedDateStartChanged)));

    public static readonly DependencyProperty SelectedDateEndProperty =
    DependencyProperty.Register(
        "SelectedDateEnd",
        typeof(DateTime?),
        typeof(StackDoubleDatePicker),
        new FrameworkPropertyMetadata(null,
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            new PropertyChangedCallback(OnSelectedDateEndChanged)));

    public string? Header { get; set; }

    public DateTime? SelectedDateStart
    {
        get { return (DateTime?)GetValue(SelectedDateStartProperty); }
        set { SetValue(SelectedDateStartProperty, value); }
    }

    public DateTime? SelectedDateEnd
    {
        get { return (DateTime?)GetValue(SelectedDateEndProperty); }
        set { SetValue(SelectedDateEndProperty, value); }
    }

    public StackDoubleDatePicker()
    {
        InitializeComponent();
    }

    private static void OnSelectedDateStartChanged(DependencyObject @object, DependencyPropertyChangedEventArgs @event)
    {
        if (@object is not StackDoubleDatePicker control || @event.NewValue is not DateTime newValue)
        {
            return;
        }

        control.SelectedDateStart = newValue;
    }

    private static void OnSelectedDateEndChanged(DependencyObject @object, DependencyPropertyChangedEventArgs @event)
    {
        if (@object is not StackDoubleDatePicker control || @event.NewValue is not DateTime newValue)
        {
            return;
        }

        control.SelectedDateEnd = newValue;
    }
}
