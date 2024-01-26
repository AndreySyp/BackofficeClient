namespace BackofficeClient.Infrastructure.Extensions;

public static class DateExtension
{
    public static DateTime ToDateTime(this DateOnly? dateOnly)
    {
        return dateOnly.ToDateTime();
    }

    public static DateOnly? ToDateOnly(this DateTime? dateTime)
    {
        return dateTime != null ? DateOnly.FromDateTime(dateTime.Value) : null;
    }
}
