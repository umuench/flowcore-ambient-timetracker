namespace FlowCore.Domain.ValueObjects;

/// <summary>
/// Definiert einen Zeitraum mit Start und optionalem Ende.
/// </summary>
public sealed class TimeRange
{
    public TimeRange(DateTimeOffset start, DateTimeOffset? end = null)
    {
        if (end is not null && end < start)
        {
            throw new ArgumentOutOfRangeException(nameof(end), "End must be greater than or equal to start.");
        }

        Start = start;
        End = end;
    }

    public DateTimeOffset Start { get; }

    public DateTimeOffset? End { get; }

    public bool IsOpen => End is null;

    public TimeSpan Duration => (End ?? Start) - Start;
}
