namespace FlowCore.Application.Commands;

/// <summary>
/// Startet den Arbeitstag für einen Nutzer.
/// </summary>
public sealed record StartWorkCommand(Guid UserId, string? Note);
