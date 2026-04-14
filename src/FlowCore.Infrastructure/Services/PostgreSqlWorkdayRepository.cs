using FlowCore.Application.Abstractions;
using FlowCore.Domain;
using FlowCore.Domain.ValueObjects;
using FlowCore.Domain.Workdays;
using FlowCore.Infrastructure.Persistence;
using FlowCore.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlowCore.Infrastructure.Services;

/// <summary>
/// PostgreSQL-Repository für Workday-Aggregate.
/// </summary>
public sealed class PostgreSqlWorkdayRepository : IWorkdayRepository
{
    private readonly FlowCoreDbContext _dbContext;

    /// <summary>
    /// Initialisiert das Repository mit DbContext.
    /// </summary>
    public PostgreSqlWorkdayRepository(FlowCoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Lädt einen Arbeitstag oder liefert ein neues Aggregat.
    /// </summary>
    public async Task<Workday> GetOrCreateAsync(Guid employeeId, DateOnly date, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Workdays
            .Include(x => x.Entries)
            .SingleOrDefaultAsync(x => x.EmployeeId == employeeId && x.Date == date, cancellationToken);

        return entity is null
            ? new Workday(Guid.NewGuid(), employeeId, date)
            : MapToDomain(entity);
    }

    /// <summary>
    /// Persistiert den Arbeitstag in PostgreSQL.
    /// </summary>
    public async Task SaveAsync(Workday workday, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Workdays
            .Include(x => x.Entries)
            .SingleOrDefaultAsync(x => x.EmployeeId == workday.EmployeeId && x.Date == workday.Date, cancellationToken);

        if (entity is null)
        {
            entity = new WorkdayEntity
            {
                Id = workday.Id,
                EmployeeId = workday.EmployeeId,
                Date = workday.Date,
            };

            foreach (var entry in workday.Entries)
            {
                entity.Entries.Add(MapToEntity(entry));
            }

            _dbContext.Workdays.Add(entity);
        }
        else
        {
            entity.Id = workday.Id;
            entity.EmployeeId = workday.EmployeeId;
            entity.Date = workday.Date;

            _dbContext.TimeEntries.RemoveRange(entity.Entries);
            entity.Entries.Clear();

            foreach (var entry in workday.Entries)
            {
                entity.Entries.Add(MapToEntity(entry));
            }
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private static Workday MapToDomain(WorkdayEntity entity)
    {
        var workday = new Workday(entity.Id, entity.EmployeeId, entity.Date);
        foreach (var entry in entity.Entries.OrderBy(x => x.Timestamp))
        {
            ActivityContext? activityContext = null;
            if (!string.IsNullOrWhiteSpace(entry.ProjectKey) && !string.IsNullOrWhiteSpace(entry.Activity))
            {
                activityContext = new ActivityContext(entry.ProjectKey, entry.Activity);
            }

            var state = Enum.TryParse<PresenceState>(entry.PresenceState, true, out var parsed)
                ? parsed
                : PresenceState.Work;

            workday.RehydrateEntry(entry.Id, state, entry.Timestamp, activityContext, entry.Note);
        }

        return workday;
    }

    private static TimeEntryEntity MapToEntity(Domain.TimeEntries.TimeEntry entry)
    {
        return new TimeEntryEntity
        {
            Id = entry.Id,
            UserId = entry.UserId,
            PresenceState = entry.Status.ToString(),
            Timestamp = entry.Timestamp,
            ProjectKey = entry.ActivityContext?.ProjectKey,
            Activity = entry.ActivityContext?.Activity,
            Note = entry.Note,
        };
    }
}
