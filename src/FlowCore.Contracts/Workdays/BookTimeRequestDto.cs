namespace FlowCore.Contracts.Workdays;

/// <summary>
/// REST-Request zum Buchen eines Zustandswechsels.
/// </summary>
public sealed record BookTimeRequestDto(Guid UserId, string PresenceState, string? Note);
