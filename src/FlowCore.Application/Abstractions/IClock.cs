namespace FlowCore.Application.Abstractions;

/// <summary>
/// Abstraktion für den aktuellen Zeitpunkt.
/// </summary>
public interface IClock
{
    DateTimeOffset UtcNow { get; }
}
