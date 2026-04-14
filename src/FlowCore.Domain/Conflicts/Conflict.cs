namespace FlowCore.Domain.Conflicts;

/// <summary>
/// Beschreibt einen erkannten Konflikt im Workday.
/// </summary>
public sealed record Conflict(string Code, string Message);
