using FlowCore.Domain;

namespace FlowCore.Application.Commands;

/// <summary>
/// Wechselt den Präsenzzustand.
/// </summary>
public sealed record ChangePresenceStateCommand(Guid UserId, PresenceState PresenceState, string? Note);
