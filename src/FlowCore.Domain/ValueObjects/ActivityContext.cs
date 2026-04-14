namespace FlowCore.Domain.ValueObjects;

/// <summary>
/// Beschreibt Projekt- und Tätigkeitskontext einer Buchung.
/// </summary>
public sealed class ActivityContext
{
    public ActivityContext(string projectKey, string activity)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(projectKey);
        ArgumentException.ThrowIfNullOrWhiteSpace(activity);

        ProjectKey = projectKey.Trim();
        Activity = activity.Trim();
    }

    public string ProjectKey { get; }

    public string Activity { get; }
}
