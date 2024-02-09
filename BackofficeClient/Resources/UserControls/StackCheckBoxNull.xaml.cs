using System.Windows;
using System.Windows.Controls;

namespace BackofficeClient.Resources.UserControls;

/// <summary>
/// Логика взаимодействия для StackCheckBoxNull.xaml
/// </summary>
public partial class StackCheckBoxNull : UserControl
{
    public static readonly DependencyProperty IsCheckedProperty =
    DependencyProperty.Register(
        "IsChecked",
        typeof(bool?),
        typeof(StackCheckBoxNull),
        new FrameworkPropertyMetadata(null,
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            new PropertyChangedCallback(OnIsCheckedChanged)));

    public string? Header { get; set; }

    public bool? IsChecked
    {
        get { return (bool?)GetValue(IsCheckedProperty); }
        set { SetValue(IsCheckedProperty, value); }
    }

    public StackCheckBoxNull()
    {
        InitializeComponent();
    }

    private static void OnIsCheckedChanged(DependencyObject @object, DependencyPropertyChangedEventArgs @event)
    {
        if (@object is not StackCheckBoxNull control)
        {
            return;
        }

        if ( @event.NewValue is null )
        {
            control.IsChecked = null;
        }
        else if (@event.NewValue is bool newValue)
        {
            control.IsChecked = newValue;
        }
    }
}
