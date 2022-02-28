namespace Elfland.Core.TimeMachine;

/// <summary>
/// Tightly couples a date and time with its associated time zone.
/// </summary>
public struct WorldClock
{
    private DateTimeOffset _dateTimeOffset;

    public DateTime DateTime
    {
        get => _dateTimeOffset.DateTime;
    }

    public TimeZoneInfo TimeZone { get; } = TimeZoneInfo.Local;

    /// <summary>
    /// Initializes a new instance of WorldClock that represents the local time.
    /// </summary>
    /// <param name="dateTime">The date and time to initialize.</param>
    public WorldClock(DateTime dateTime)
    {
        _dateTimeOffset = dateTime;

        if (dateTime.Kind is DateTimeKind.Utc)
        {
            TimeZone = TimeZoneInfo.Utc;
        }
    }

    /// <summary>
    /// Initializes a new instance of WorldClock that represents the time with a particular time zone.
    /// </summary>
    /// <param name="dateTime">The date and time to initialize.</param>
    /// <param name="timeZone">The time zone to initialize.</param>
    public WorldClock(DateTime dateTime, TimeZoneInfo timeZone)
    {
        _dateTimeOffset = dateTime;
        TimeZone = timeZone ?? throw new ArgumentNullException(nameof(timeZone));
    }

    /// <summary>
    /// Initializes a new instance of WorldClock that represents the date and time with a particular time zone based on the time zone's identifier.
    /// </summary>
    /// <param name="dateTime">The date and time to initialize.</param>
    /// <param name="timeZone">The time zone to initialize.</param>
    public WorldClock(DateTime dateTime, string timeZoneId)
    {
        if (string.IsNullOrEmpty(timeZoneId))
        {
            throw new ArgumentException(
                $"'{nameof(timeZoneId)}' cannot be null or empty.",
                nameof(timeZoneId)
            );
        }

        _dateTimeOffset = dateTime;
        TimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
    }

    /// <summary>
    /// Converts a time to the time in a particular time zone.
    /// </summary>
    /// <param name="destinationTimeZone">The time zone to convert dateTime to.</param>
    /// <returns></returns>
    public WorldClock ConvertTime(TimeZoneInfo destinationTimeZone) =>
        new WorldClock(
            TimeZoneInfo.ConvertTime(DateTime, TimeZone, destinationTimeZone),
            destinationTimeZone
        );

    /// <summary>
    /// Converts a time to the time in another time zone based on the time zone's identifier.
    /// </summary>
    /// <param name="destinationTimeZoneId">The identifier of the destination time zone.</param>
    /// <returns></returns>
    public WorldClock ConvertTime(string destinationTimeZoneId) =>
        new WorldClock(
            TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
                DateTime,
                TimeZone.Id,
                destinationTimeZoneId
            ),
            destinationTimeZoneId
        );
}
