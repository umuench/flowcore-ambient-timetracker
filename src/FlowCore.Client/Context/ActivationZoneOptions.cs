namespace FlowCore.Client.Context;

/// <summary>
/// Konfigurationsmodell für Aktivierungszonen und Fallback-Verhalten.
/// </summary>
public sealed class ActivationZoneOptions
{
    public const string SectionName = "Client:ActivationZones";

    public bool UseLastInteractionContextFallback { get; set; } = true;

    public List<MonitorActivationZone> Zones { get; } = new();
}
