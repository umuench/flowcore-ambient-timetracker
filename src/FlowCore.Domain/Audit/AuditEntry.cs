namespace FlowCore.Domain.Audit;

/// <summary>
/// Protokolliert fachliche Änderungen revisionssicher.
/// </summary>
public sealed record AuditEntry(Guid EntityId, string Action, string PerformedBy, DateTimeOffset PerformedAt, string? Reason);
