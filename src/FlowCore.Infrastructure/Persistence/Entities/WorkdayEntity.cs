namespace FlowCore.Infrastructure.Persistence.Entities;

/// <summary>
/// Persistenzmodell für Workday.
/// </summary>
public sealed class WorkdayEntity
{
    public Guid Id { get; set; }

    public Guid EmployeeId { get; set; }

    public DateOnly Date { get; set; }

    public List<TimeEntryEntity> Entries { get; set; } = new();
}
