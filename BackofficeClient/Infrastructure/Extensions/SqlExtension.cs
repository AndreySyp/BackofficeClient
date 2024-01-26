namespace BackofficeClient.Infrastructure.Extensions;

public static class SqlExtension
{
    public static string? OldOrNew(this string? old, string? @new)
    {
        return string.IsNullOrWhiteSpace(@new) ? old : @new;
    }

    public static bool OldOrNew(this bool old, bool? @new)
    {
        return @new == null ? old : (bool)@new;
    }

    public static DateOnly? OldOrNew(this DateOnly? old, DateOnly? @new)
    {
        return @new == null ? old : @new;
    }

    public static string OldOrNewNotNull(this string old, string? @new)
    {
        return (@new == null || string.IsNullOrWhiteSpace(@new)) ? old : @new;
    }
}
