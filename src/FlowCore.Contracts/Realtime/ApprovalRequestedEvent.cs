namespace FlowCore.Contracts.Realtime;

/// <summary>
/// Realtime-Ereignis für genehmigungspflichtige Korrekturen.
/// </summary>
public sealed record ApprovalRequestedEvent(Guid ApprovalRequestId, Guid UserId, string Reason, DateTimeOffset RequestedAt);
