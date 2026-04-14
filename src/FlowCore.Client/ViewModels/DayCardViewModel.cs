using FlowCore.Domain.TimeEntries;

namespace FlowCore.Client.ViewModels;

/// <summary>
/// ViewModel für die Tageskarte.
/// </summary>
public sealed class DayCardViewModel
{
    public DateOnly Date { get; init; }

    public IReadOnlyList<TimeEntry> Entries { get; init; } = Array.Empty<TimeEntry>();
}
