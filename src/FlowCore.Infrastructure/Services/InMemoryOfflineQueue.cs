using System.Collections.Concurrent;

namespace FlowCore.Infrastructure.Services;

/// <summary>
/// Einfache In-Memory-Queue als Baseline für Offline-Sync.
/// </summary>
public sealed class InMemoryOfflineQueue
{
    private readonly ConcurrentQueue<string> _queue = new();

    public int Count => _queue.Count;

    /// <summary>
    /// Hängt ein Payload-Element an die Queue an.
    /// </summary>
    public void Enqueue(string payload)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(payload);
        _queue.Enqueue(payload);
    }

    /// <summary>
    /// Holt das nächste Queue-Element, wenn vorhanden.
    /// </summary>
    public bool TryDequeue(out string? payload)
    {
        return _queue.TryDequeue(out payload);
    }
}
