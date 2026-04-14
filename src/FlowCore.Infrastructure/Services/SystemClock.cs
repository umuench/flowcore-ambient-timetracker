using FlowCore.Application.Abstractions;

namespace FlowCore.Infrastructure.Services;

/// <summary>
/// Produktionsimplementierung für Zeitabfragen.
/// </summary>
public sealed class SystemClock : IClock, ISystemClock
{
    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}
