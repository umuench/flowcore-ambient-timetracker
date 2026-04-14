using FlowCore.Domain.Approvals;

namespace FlowCore.Application.Abstractions;

/// <summary>
/// Persistenzzugriff für Genehmigungsanfragen.
/// </summary>
public interface IApprovalRequestRepository
{
    Task SaveAsync(ApprovalRequest request, CancellationToken cancellationToken);
}
