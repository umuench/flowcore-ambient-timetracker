namespace FlowCore.Client.Context;

/// <summary>
/// Aktivierungszone für einen Monitor.
/// </summary>
public sealed record MonitorActivationZone(string MonitorId, string Name, NormalizedRect Area)
{
    public bool IsMatch(string monitorId, double normalizedX, double normalizedY)
    {
        return string.Equals(MonitorId, monitorId, StringComparison.OrdinalIgnoreCase)
            && Area.Contains(normalizedX, normalizedY);
    }
}
