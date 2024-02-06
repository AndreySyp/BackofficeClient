using System.Windows;
using System.Windows.Controls;

namespace BackofficeClient.Resources.UserControls;

/// <summary>
/// Логика взаимодействия для StackTextBox.xaml
/// </summary>
public partial class StackTextBox : UserControl
{
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(
            "Text",
            typeof(string),
            typeof(StackTextBox),
            new FrameworkPropertyMetadata(null,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                new PropertyChangedCallback(OnTextChanged)));

    public string? Header { get; set; }

    public string? Text
    {
        get { return (string?)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }

    public StackTextBox()
    {
        InitializeComponent();
    }

    private static void OnTextChanged(DependencyObject @object, DependencyPropertyChangedEventArgs @event)
    {
        if (@object is not StackTextBox control)
        {
            return;
        }
        control.Text = @event.NewValue as string;
    }
}
