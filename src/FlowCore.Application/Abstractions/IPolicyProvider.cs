using FlowCore.Domain.Policies;

namespace FlowCore.Application.Abstractions;

/// <summary>
/// Liefert Regelwerke für Mitarbeitende oder Abteilungen.
/// </summary>
public interface IPolicyProvider
{
    Task<CorrectionWindowPolicy> GetCorrectionWindowPolicyAsync(Guid employeeId, CancellationToken cancellationToken);

    Task<BreakPolicy> GetBreakPolicyAsync(Guid employeeId, CancellationToken cancellationToken);
}
