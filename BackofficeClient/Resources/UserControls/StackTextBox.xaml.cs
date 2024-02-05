using System.Windows;
using System.Windows.Controls;

namespace BackofficeClient.Resources.UserControls;

/// <summary>
/// Логика взаимодействия для StackTextBox.xaml
/// </summary>
public partial class StackTextBox : UserControl
{
    public StackTextBox()
    {
        InitializeComponent();
    }

    public string? Header { get; set; }

    public string? Items
    {
        get { return (string?)GetValue(ItemsProperty); }
        set { SetValue(ItemsProperty, value); }
    }

    public static readonly DependencyProperty ItemsProperty =
        DependencyProperty.Register(
            "Items",
            typeof(string),
            typeof(StackTextBox),
            new FrameworkPropertyMetadata(string.Empty,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                new PropertyChangedCallback(OnTextChanged)));

    private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is not StackTextBox stackTextBox)
        {
            return;
        }
        string? a = e.NewValue as string;
        stackTextBox.Items = a;
    }
}
