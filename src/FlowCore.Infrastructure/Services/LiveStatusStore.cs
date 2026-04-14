using System.Collections.Concurrent;
using FlowCore.Contracts.Admin;
using FlowCore.Domain;

namespace FlowCore.Infrastructure.Services;

/// <summary>
/// In-Memory-Live-Statusstore für Team- und Admin-Sichten.
/// </summary>
public sealed class LiveStatusStore
{
    private readonly ConcurrentDictionary<Guid, LiveStatusDto> _statuses = new();

    /// <summary>
    /// Aktualisiert den letzten bekannten Präsenzstatus eines Nutzers.
    /// </summary>
    public void Update(Guid userId, PresenceState presenceState, DateTimeOffset changedAt)
    {
        _statuses[userId] = new LiveStatusDto(userId, presenceState.ToString(), changedAt);
    }

    /// <summary>
    /// Liefert alle aktuellen Live-Status-Datensätze.
    /// </summary>
    public IReadOnlyList<LiveStatusDto> GetAll()
    {
        return _statuses.Values.OrderBy(x => x.UserId).ToArray();
    }
}
