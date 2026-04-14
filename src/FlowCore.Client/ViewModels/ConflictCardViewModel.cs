using FlowCore.Domain.Conflicts;

namespace FlowCore.Client.ViewModels;

/// <summary>
/// ViewModel für Konflikthinweise.
/// </summary>
public sealed class ConflictCardViewModel
{
    public IReadOnlyList<Conflict> Conflicts { get; init; } = Array.Empty<Conflict>();

    public bool HasConflicts => Conflicts.Count > 0;
}
