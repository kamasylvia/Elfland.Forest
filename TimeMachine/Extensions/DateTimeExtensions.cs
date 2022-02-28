namespace Elfland.Core.TimeMachine.Extensions;

public static class DateTimeExtensions
{
    public static DateOnly ToDateOnly(this DateTime dateTime) => DateOnly.FromDateTime(dateTime);

    public static DateOnly? ToDateOnly(this DateTime? dateTime) =>
        dateTime.HasValue ? DateOnly.FromDateTime(dateTime.Value) : null;

    public static TimeOnly ToTimeOnly(this DateTime dateTime) => TimeOnly.FromDateTime(dateTime);

    public static TimeOnly? ToTimeOnly(this DateTime? dateTime) =>
        dateTime.HasValue ? TimeOnly.FromDateTime(dateTime.Value) : null;

    public static DateTime ToDateTime(this DateOnly dateOnly) =>
        dateOnly.ToDateTime(new TimeOnly(0, 0)).Date;

    public static DateTime? ToDateTime(this DateOnly? dateOnly) =>
        dateOnly.HasValue ? dateOnly.Value.ToDateTime(new TimeOnly()) : null;

    public static TimeOnly ToTimeOnly(this TimeSpan timeSpan) => TimeOnly.FromTimeSpan(timeSpan);
}
