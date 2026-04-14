using FlowCore.Application.Abstractions;

namespace FlowCore.Infrastructure.Services;

/// <summary>
/// Baseline-Publisher ohne externen Broker.
/// </summary>
public sealed class NoopDomainEventPublisher : IDomainEventPublisher
{
    public Task PublishAsync<TEvent>(TEvent domainEvent, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
