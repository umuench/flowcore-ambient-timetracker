namespace FlowCore.Application.Queries;

/// <summary>
/// Fragt Konflikte und Lücken eines Arbeitstages ab.
/// </summary>
public sealed record WorkdayConflictsQuery(Guid UserId, DateOnly Date);
