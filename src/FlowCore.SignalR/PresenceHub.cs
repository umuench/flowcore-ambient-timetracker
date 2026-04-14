using FlowCore.Contracts.Realtime;
using Microsoft.AspNetCore.SignalR;

namespace FlowCore.SignalR;

/// <summary>
/// Realtime-Hub für Presence-, Policy- und Freigabeereignisse.
/// </summary>
public sealed class PresenceHub : Hub<IPresenceClient>
{
    /// <summary>
    /// Verteilt Statusänderungen an alle verbundenen Clients.
    /// </summary>
    public Task PublishStatusChange(PresenceChangedEvent message)
    {
        return Clients.All.ReceiveStatusChange(message);
    }

    /// <summary>
    /// Verteilt Policy-Updates an alle verbundenen Clients.
    /// </summary>
    public Task PublishPolicyUpdate(PolicyUpdatedEvent message)
    {
        return Clients.All.ReceivePolicyUpdate(message);
    }

    /// <summary>
    /// Verteilt neu erzeugte Genehmigungsanfragen.
    /// </summary>
    public Task PublishApprovalRequested(ApprovalRequestedEvent message)
    {
        return Clients.All.ReceiveApprovalRequested(message);
    }

    /// <summary>
    /// Verteilt Konflikthinweise an alle verbundenen Clients.
    /// </summary>
    public Task PublishConflictHint(ConflictHintEvent message)
    {
        return Clients.All.ReceiveConflictHint(message);
    }
}

/// <summary>
/// Clientvertrag für Presence- und Admin-Realtime-Events.
/// </summary>
public interface IPresenceClient
{
    Task ReceiveStatusChange(PresenceChangedEvent message);

    Task ReceivePolicyUpdate(PolicyUpdatedEvent message);

    Task ReceiveApprovalRequested(ApprovalRequestedEvent message);

    Task ReceiveConflictHint(ConflictHintEvent message);
}
