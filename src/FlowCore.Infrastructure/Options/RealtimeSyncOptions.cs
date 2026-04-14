namespace FlowCore.Infrastructure.Options;

/// <summary>
/// Konfiguration für Realtime und REST-Fallback.
/// </summary>
public sealed class RealtimeSyncOptions
{
    public const string SectionName = "RealtimeSync";

    public int ReconnectDelaySeconds { get; set; } = 3;

    public int MaxReconnectDelaySeconds { get; set; } = 30;

    public bool EnableRestFallback { get; set; } = true;
}
