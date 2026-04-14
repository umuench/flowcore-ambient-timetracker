namespace FlowCore.Domain.Policies;

/// <summary>
/// Definiert Mindestpausenregeln abhängig von Arbeitsdauer.
/// </summary>
public sealed class BreakPolicy
{
    public BreakPolicy(TimeSpan mandatoryBreakAfter, TimeSpan minimumBreakDuration)
    {
        if (mandatoryBreakAfter <= TimeSpan.Zero)
        {
            throw new ArgumentOutOfRangeException(nameof(mandatoryBreakAfter));
        }

        if (minimumBreakDuration <= TimeSpan.Zero)
        {
            throw new ArgumentOutOfRangeException(nameof(minimumBreakDuration));
        }

        MandatoryBreakAfter = mandatoryBreakAfter;
        MinimumBreakDuration = minimumBreakDuration;
    }

    public TimeSpan MandatoryBreakAfter { get; }

    public TimeSpan MinimumBreakDuration { get; }
}
