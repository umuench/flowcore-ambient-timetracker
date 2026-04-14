namespace FlowCore.Application.Commands;

/// <summary>
/// Wechselt Projekt- oder Tätigkeitskontext.
/// </summary>
public sealed record ChangeActivityContextCommand(Guid UserId, string ProjectKey, string Activity, string? Note);
