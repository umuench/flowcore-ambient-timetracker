using System.Collections.Concurrent;
using FlowCore.Domain.Audit;

namespace FlowCore.Infrastructure.Services;

/// <summary>
/// In-Memory-Auditstore als Persistenzbasis.
/// </summary>
public sealed class AuditTrailStore
{
    private readonly ConcurrentQueue<AuditEntry> _entries = new();

    /// <summary>
    /// Fügt einen Audit-Eintrag hinzu.
    /// </summary>
    public void Add(AuditEntry entry)
    {
        _entries.Enqueue(entry);
    }

    /// <summary>
    /// Liefert die neuesten Audit-Einträge.
    /// </summary>
    public IReadOnlyList<AuditEntry> GetLatest(int max = 100)
    {
        return _entries.Reverse().Take(max).ToArray();
    }
}
