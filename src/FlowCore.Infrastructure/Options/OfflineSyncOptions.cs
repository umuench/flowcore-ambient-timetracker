namespace FlowCore.Infrastructure.Options;

/// <summary>
/// Konfiguration für den Offline-Synchronisationspfad.
/// </summary>
public sealed class OfflineSyncOptions
{
    public const string SectionName = "OfflineSync";

    public int MaxQueueLength { get; set; } = 1000;
}
