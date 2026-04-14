namespace FlowCore.Infrastructure.Persistence.Entities;

/// <summary>
/// Persistenzmodell für TimeEntry.
/// </summary>
public sealed class TimeEntryEntity
{
    public Guid Id { get; set; }

    public Guid WorkdayId { get; set; }

    public Guid UserId { get; set; }

    public string PresenceState { get; set; } = string.Empty;

    public DateTimeOffset Timestamp { get; set; }

    public string? ProjectKey { get; set; }

    public string? Activity { get; set; }

    public string? Note { get; set; }

    public WorkdayEntity Workday { get; set; } = null!;
}
