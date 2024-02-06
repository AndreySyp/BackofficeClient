using System.Windows;
using System.Windows.Controls;

namespace BackofficeClient.Resources.UserControls;

/// <summary>
/// Логика взаимодействия для StackCheckBox.xaml
/// </summary>
public partial class StackCheckBox : UserControl
{
    public static readonly DependencyProperty IsCheckedProperty =
    DependencyProperty.Register(
        "IsChecked",
        typeof(bool),
        typeof(StackCheckBox),
        new FrameworkPropertyMetadata(false,
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            new PropertyChangedCallback(OnIsCheckedChanged)));

    public string? Header { get; set; }

    public bool IsChecked
    {
        get { return (bool)GetValue(IsCheckedProperty); }
        set { SetValue(IsCheckedProperty, value); }
    }

    public StackCheckBox()
    {
        InitializeComponent();
    }

    private static void OnIsCheckedChanged(DependencyObject @object, DependencyPropertyChangedEventArgs @event)
    {
        if (@object is not StackCheckBox control || @event.NewValue is not bool newValue)
        {
            return;
        }

        control.IsChecked = newValue;
    }
}
