using FlowCore.Contracts.Statuses;
using FlowCore.Domain;

namespace FlowCore.Application.Queries;

/// <summary>
/// Liefert die verfügbare Statusauswahl für Client und API.
/// </summary>
public sealed class StatusCatalog
{
    public IReadOnlyList<StatusDto> GetAll()
    {
        return Enum.GetValues<PresenceState>()
            .Select(value => new StatusDto((int)value, value.ToString()))
            .ToArray();
    }
}
