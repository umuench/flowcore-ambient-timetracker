using Xunit;
using FlowCore.Infrastructure.Services;

namespace FlowCore.Infrastructure.Tests;

public sealed class InMemoryOfflineQueueTests
{
    [Fact]
    public void EnqueueAndTryDequeue_RoundtripWorks()
    {
        var queue = new InMemoryOfflineQueue();
        queue.Enqueue("payload");

        var dequeued = queue.TryDequeue(out var value);

        Assert.True(dequeued);
        Assert.Equal("payload", value);
        Assert.Equal(0, queue.Count);
    }
}
