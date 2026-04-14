namespace FlowCore.Contracts.Workdays;

/// <summary>
/// REST-Request zur Korrektur einer Zeitbuchung.
/// </summary>
public sealed record CorrectTimeEntryRequestDto(Guid UserId, Guid TimeEntryId, DateTimeOffset CorrectedTimestamp, string Reason);
