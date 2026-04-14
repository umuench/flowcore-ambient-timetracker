namespace FlowCore.Application.Commands;

/// <summary>
/// Korrigiert eine bestehende Buchung.
/// </summary>
public sealed record CorrectTimeEntryCommand(Guid UserId, Guid TimeEntryId, DateTimeOffset CorrectedTimestamp, string Reason);
