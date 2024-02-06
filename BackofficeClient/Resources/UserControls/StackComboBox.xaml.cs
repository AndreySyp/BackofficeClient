using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace BackofficeClient.Resources.UserControls;

/// <summary>
/// Логика взаимодействия для StackComboBox.xaml
/// </summary>
public partial class StackComboBox : UserControl
{
    public static readonly DependencyProperty ItemsSourceProperty =
        DependencyProperty.Register(
            "ItemsSource",
            typeof(IEnumerable),
            typeof(StackComboBox),
            new FrameworkPropertyMetadata(null,
            new PropertyChangedCallback(OnItemsSourceChanged)));

    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(
            "Text",
            typeof(string),
            typeof(StackComboBox),
            new FrameworkPropertyMetadata(null,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                new PropertyChangedCallback(OnTextChanged)));

    public string? Header { get; set; }

    public IEnumerable ItemsSource
    {
        get { return (IEnumerable)GetValue(ItemsSourceProperty); }
        set { SetValue(ItemsSourceProperty, value); }
    }

    public string? Text
    {
        get { return (string?)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }

    public StackComboBox()
    {
        InitializeComponent();
    }

    private static void OnItemsSourceChanged(DependencyObject @object, DependencyPropertyChangedEventArgs @event)
    {
        if (@object is not StackComboBox control || @event.NewValue is not IEnumerable newValue)
        {
            return;
        }

        control.ItemsSource = newValue;
    }

    private static void OnTextChanged(DependencyObject @object, DependencyPropertyChangedEventArgs @event)
    {
        if (@object is not StackComboBox control)
        {
            return;
        }

        control.Text = @event.NewValue as string;
    }
}
