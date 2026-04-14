namespace FlowCore.Domain.Policies;

/// <summary>
/// Definiert Kernzeit- und Tagesarbeitszeitgrenzen.
/// </summary>
public sealed class FlexTimeModel
{
    public FlexTimeModel(TimeSpan expectedDailyHours, TimeSpan coreStart, TimeSpan coreEnd)
    {
        if (expectedDailyHours <= TimeSpan.Zero)
        {
            throw new ArgumentOutOfRangeException(nameof(expectedDailyHours));
        }

        if (coreEnd <= coreStart)
        {
            throw new ArgumentOutOfRangeException(nameof(coreEnd), "Core end must be later than core start.");
        }

        ExpectedDailyHours = expectedDailyHours;
        CoreStart = coreStart;
        CoreEnd = coreEnd;
    }

    public TimeSpan ExpectedDailyHours { get; }

    public TimeSpan CoreStart { get; }

    public TimeSpan CoreEnd { get; }
}
