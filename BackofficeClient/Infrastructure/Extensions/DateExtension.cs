namespace BackofficeClient.Infrastructure.Extensions;

public static class DateExtension
{
    public static DateTime ToDateTime(this DateOnly? dateOnly)
    {
        if (dateOnly == null)
        {
            return default;
        }
        return dateOnly.Value.ToDateTime(new TimeOnly());
    }

    public static DateOnly? ToDateOnly(this DateTime? dateTime)
    {
        return dateTime != null ? DateOnly.FromDateTime(dateTime.Value) : null;
    }
}
