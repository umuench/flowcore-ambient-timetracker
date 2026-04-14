using FlowCore.Domain.Workdays;

namespace FlowCore.Application.Abstractions;

/// <summary>
/// Persistenzzugriff für Workday-Aggregate.
/// </summary>
public interface IWorkdayRepository
{
    Task<Workday> GetOrCreateAsync(Guid employeeId, DateOnly date, CancellationToken cancellationToken);

    Task SaveAsync(Workday workday, CancellationToken cancellationToken);
}
