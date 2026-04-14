using System.Collections.Concurrent;
using FlowCore.Application.Abstractions;
using FlowCore.Domain.Workdays;

namespace FlowCore.Infrastructure.Services;

/// <summary>
/// In-Memory-Repositorium für Workday-Aggregate (Baseline).
/// </summary>
public sealed class InMemoryWorkdayRepository : IWorkdayRepository
{
    private readonly ConcurrentDictionary<string, Workday> _store = new();

    /// <summary>
    /// Lädt den Arbeitstag oder erzeugt ihn bei Erstzugriff.
    /// </summary>
    public Task<Workday> GetOrCreateAsync(Guid employeeId, DateOnly date, CancellationToken cancellationToken)
    {
        var key = $"{employeeId:N}:{date:yyyyMMdd}";
        var workday = _store.GetOrAdd(key, _ => new Workday(Guid.NewGuid(), employeeId, date));
        return Task.FromResult(workday);
    }

    /// <summary>
    /// Persistiert den Arbeitstag im Store.
    /// </summary>
    public Task SaveAsync(Workday workday, CancellationToken cancellationToken)
    {
        var key = $"{workday.EmployeeId:N}:{workday.Date:yyyyMMdd}";
        _store[key] = workday;
        return Task.CompletedTask;
    }
}
