namespace FlowCore.Contracts.Realtime;

/// <summary>
/// Realtime-Ereignis für aktualisierte Policy-Konfigurationen.
/// </summary>
public sealed record PolicyUpdatedEvent(string PolicyKey, string ChangedBy, DateTimeOffset ChangedAt);
