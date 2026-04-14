namespace FlowCore.Contracts.Realtime;

/// <summary>
/// Realtime-Hinweis auf erkannte Konflikte oder Lücken.
/// </summary>
public sealed record ConflictHintEvent(Guid UserId, int Count, DateTimeOffset CreatedAt);
