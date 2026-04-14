namespace FlowCore.Contracts.Realtime;

/// <summary>
/// Realtime-Ereignis für Statusänderungen.
/// </summary>
public sealed record PresenceChangedEvent(Guid UserId, string Status, DateTimeOffset ChangedAt);
