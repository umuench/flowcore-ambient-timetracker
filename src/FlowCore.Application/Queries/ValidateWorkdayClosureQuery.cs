namespace FlowCore.Application.Queries;

/// <summary>
/// Prüft, ob ein Arbeitstag abschließbar ist.
/// </summary>
public sealed record ValidateWorkdayClosureQuery(Guid UserId, DateOnly Date);
