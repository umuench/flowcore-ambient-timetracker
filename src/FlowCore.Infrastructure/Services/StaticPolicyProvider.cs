using FlowCore.Application.Abstractions;
using FlowCore.Domain.Policies;

namespace FlowCore.Infrastructure.Services;

/// <summary>
/// Liefert statische Policies als Baseline.
/// </summary>
public sealed class StaticPolicyProvider : IPolicyProvider
{
    private static readonly CorrectionWindowPolicy CorrectionPolicy = new(TimeSpan.FromHours(24));
    private static readonly BreakPolicy BreakPolicy = new(TimeSpan.FromHours(6), TimeSpan.FromMinutes(30));

    /// <summary>
    /// Liefert die Korrekturfenster-Policy.
    /// </summary>
    public Task<CorrectionWindowPolicy> GetCorrectionWindowPolicyAsync(Guid employeeId, CancellationToken cancellationToken)
    {
        return Task.FromResult(CorrectionPolicy);
    }

    /// <summary>
    /// Liefert die Pausen-Policy.
    /// </summary>
    public Task<BreakPolicy> GetBreakPolicyAsync(Guid employeeId, CancellationToken cancellationToken)
    {
        return Task.FromResult(BreakPolicy);
    }
}
