using FlowCore.Domain.ValueObjects;

namespace FlowCore.Domain.TimeEntries;

/// <summary>
/// Repräsentiert eine Zeitbuchung im Tagesverlauf.
/// </summary>
public sealed class TimeEntry
{
    public TimeEntry(Guid id, Guid userId, PresenceState status, DateTimeOffset timestamp, ActivityContext? activityContext = null, string? note = null)
    {
        Id = id;
        UserId = userId;
        Status = status;
        Timestamp = timestamp;
        ActivityContext = activityContext;
        Note = note;
    }

    public Guid Id { get; }

    public Guid UserId { get; }

    public PresenceState Status { get; }

    public DateTimeOffset Timestamp { get; }

    public ActivityContext? ActivityContext { get; }

    public string? Note { get; }

    /// <summary>
    /// Erzeugt eine Kopie mit korrigiertem Zeitstempel.
    /// </summary>
    public TimeEntry WithTimestamp(DateTimeOffset correctedTimestamp)
    {
        return new TimeEntry(Id, UserId, Status, correctedTimestamp, ActivityContext, Note);
    }
}
