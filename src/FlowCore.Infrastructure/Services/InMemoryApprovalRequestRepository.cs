using System.Collections.Concurrent;
using FlowCore.Application.Abstractions;
using FlowCore.Domain.Approvals;

namespace FlowCore.Infrastructure.Services;

/// <summary>
/// In-Memory-Persistenz für Genehmigungsanfragen.
/// </summary>
public sealed class InMemoryApprovalRequestRepository : IApprovalRequestRepository
{
    private readonly ConcurrentDictionary<Guid, ApprovalRequest> _store = new();

    /// <summary>
    /// Speichert eine Genehmigungsanfrage.
    /// </summary>
    public Task SaveAsync(ApprovalRequest request, CancellationToken cancellationToken)
    {
        _store[request.Id] = request;
        return Task.CompletedTask;
    }
}
