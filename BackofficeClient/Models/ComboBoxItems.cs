namespace BackofficeClient.Models;

class ComboBoxItems
{
    private static IEnumerable<string>? priorityItems;
    private static IEnumerable<string>? directionItems;
    private static IEnumerable<string>? tradeSignItems;
    private static IEnumerable<string>? statusItems;
    private static IEnumerable<string>? currencyItems;
    private static IEnumerable<string>? personItems;
    private static IEnumerable<string>? measureItems;

    public static IEnumerable<string> PriorityItems { get => priorityItems ?? []; set => priorityItems = value; }

    public static IEnumerable<string> DirectionItems { get => directionItems ?? []; set => directionItems = value; }

    public static IEnumerable<string> TradeSignItems { get => tradeSignItems ?? []; set => tradeSignItems = value; }

    public static IEnumerable<string> StatusItems { get => statusItems ?? []; set => statusItems = value; }

    public static IEnumerable<string> CurrencyItems { get => currencyItems ?? []; set => currencyItems = value; }

    public static IEnumerable<string> PersonItems { get => personItems ?? []; set => personItems = value; }

    public static IEnumerable<string> MeasureItems { get => measureItems ?? []; set => measureItems = value; }
}
