namespace FlowCore.Application.Commands;

/// <summary>
/// Startet eine Pause.
/// </summary>
public sealed record StartBreakCommand(Guid UserId, string? Note);
