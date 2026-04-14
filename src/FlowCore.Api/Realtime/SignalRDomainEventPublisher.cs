using FlowCore.Application.Abstractions;
using FlowCore.Contracts.Realtime;
using FlowCore.Domain.Audit;
using FlowCore.Infrastructure.Services;
using FlowCore.SignalR;
using Microsoft.AspNetCore.SignalR;

namespace FlowCore.Api.Realtime;

/// <summary>
/// Publiziert Domänenereignisse an SignalR und schreibt Audit-Einträge.
/// </summary>
public sealed class SignalRDomainEventPublisher : IDomainEventPublisher
{
    private readonly IHubContext<PresenceHub, IPresenceClient> _hubContext;
    private readonly LiveStatusStore _liveStatusStore;
    private readonly AuditTrailStore _auditTrailStore;
    private readonly ILogger<SignalRDomainEventPublisher> _logger;

    public SignalRDomainEventPublisher(
        IHubContext<PresenceHub, IPresenceClient> hubContext,
        LiveStatusStore liveStatusStore,
        AuditTrailStore auditTrailStore,
        ILogger<SignalRDomainEventPublisher> logger)
    {
        _hubContext = hubContext;
        _liveStatusStore = liveStatusStore;
        _auditTrailStore = auditTrailStore;
        _logger = logger;
    }

    /// <summary>
    /// Publiziert unterstützte Domänenereignisse an Realtime-Clients und Auditstore.
    /// </summary>
    public async Task PublishAsync<TEvent>(TEvent domainEvent, CancellationToken cancellationToken)
    {
        switch (domainEvent)
        {
            case PresenceChangedEvent presenceChanged:
                _liveStatusStore.Update(presenceChanged.UserId, Enum.Parse<FlowCore.Domain.PresenceState>(presenceChanged.Status), presenceChanged.ChangedAt);
                _auditTrailStore.Add(new AuditEntry(presenceChanged.UserId, "PresenceChanged", "system", presenceChanged.ChangedAt, presenceChanged.Status));
                await _hubContext.Clients.All.ReceiveStatusChange(presenceChanged);
                _logger.LogInformation("Published PresenceChangedEvent for user {UserId} with status {Status}", presenceChanged.UserId, presenceChanged.Status);
                break;

            case PolicyUpdatedEvent policyUpdated:
                _auditTrailStore.Add(new AuditEntry(Guid.Empty, "PolicyUpdated", policyUpdated.ChangedBy, policyUpdated.ChangedAt, policyUpdated.PolicyKey));
                await _hubContext.Clients.All.ReceivePolicyUpdate(policyUpdated);
                break;

            case ApprovalRequestedEvent approvalRequested:
                _auditTrailStore.Add(new AuditEntry(approvalRequested.ApprovalRequestId, "ApprovalRequested", "system", approvalRequested.RequestedAt, approvalRequested.Reason));
                await _hubContext.Clients.All.ReceiveApprovalRequested(approvalRequested);
                break;

            case ConflictHintEvent conflictHint:
                _auditTrailStore.Add(new AuditEntry(conflictHint.UserId, "ConflictHint", "system", conflictHint.CreatedAt, $"Count={conflictHint.Count}"));
                await _hubContext.Clients.All.ReceiveConflictHint(conflictHint);
                break;

            default:
                _logger.LogDebug("Ignoring unsupported event type {EventType}", typeof(TEvent).Name);
                break;
        }
    }
}
