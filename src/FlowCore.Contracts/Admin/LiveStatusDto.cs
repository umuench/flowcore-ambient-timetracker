namespace FlowCore.Contracts.Admin;

/// <summary>
/// Live-Statusdarstellung für Team- und Admin-Sichten.
/// </summary>
public sealed record LiveStatusDto(Guid UserId, string PresenceState, DateTimeOffset ChangedAt);
