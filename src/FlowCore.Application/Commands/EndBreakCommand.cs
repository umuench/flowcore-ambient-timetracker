namespace FlowCore.Application.Commands;

/// <summary>
/// Beendet eine Pause.
/// </summary>
public sealed record EndBreakCommand(Guid UserId, string? Note);
