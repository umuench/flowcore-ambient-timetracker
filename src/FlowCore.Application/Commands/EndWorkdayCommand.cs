namespace FlowCore.Application.Commands;

/// <summary>
/// Beendet den Arbeitstag.
/// </summary>
public sealed record EndWorkdayCommand(Guid UserId, string? Note);
