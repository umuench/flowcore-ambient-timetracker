namespace FlowCore.Application.Abstractions;

/// <summary>
/// Publiziert Domänenereignisse für Realtime- und Integrationspfade.
/// </summary>
public interface IDomainEventPublisher
{
    Task PublishAsync<TEvent>(TEvent domainEvent, CancellationToken cancellationToken);
}
