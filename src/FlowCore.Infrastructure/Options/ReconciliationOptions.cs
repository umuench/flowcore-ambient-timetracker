namespace FlowCore.Infrastructure.Options;

/// <summary>
/// Optionen für den Abgleich von Offline-Queue und Serverzustand.
/// </summary>
public sealed class ReconciliationOptions
{
    public const string SectionName = "Reconciliation";

    public int MaxReplayBatchSize { get; set; } = 100;

    public bool UseIdempotencyKeys { get; set; } = true;
}
