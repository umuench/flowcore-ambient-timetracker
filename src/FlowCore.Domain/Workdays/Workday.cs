using FlowCore.Domain.Conflicts;
using FlowCore.Domain.Policies;
using FlowCore.Domain.TimeEntries;
using FlowCore.Domain.ValueObjects;

namespace FlowCore.Domain.Workdays;

/// <summary>
/// Aggregat für den Arbeitstag eines Mitarbeitenden.
/// </summary>
public sealed class Workday
{
    private readonly List<TimeEntry> _entries = new();

    /// <summary>
    /// Initialisiert einen Arbeitstag.
    /// </summary>
    public Workday(Guid id, Guid employeeId, DateOnly date)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Workday id must not be empty.", nameof(id));
        }

        if (employeeId == Guid.Empty)
        {
            throw new ArgumentException("Employee id must not be empty.", nameof(employeeId));
        }

        Id = id;
        EmployeeId = employeeId;
        Date = date;
    }

    public Guid Id { get; }

    public Guid EmployeeId { get; }

    public DateOnly Date { get; }

    public IReadOnlyCollection<TimeEntry> Entries => _entries.AsReadOnly();

    public PresenceState CurrentState => _entries.OrderBy(x => x.Timestamp).LastOrDefault()?.Status ?? PresenceState.Work;

    /// <summary>
    /// Fügt einen neuen Zeiteintrag hinzu.
    /// </summary>
    public void AddEntry(PresenceState state, DateTimeOffset timestamp, ActivityContext? activityContext = null, string? note = null)
    {
        _entries.Add(new TimeEntry(Guid.NewGuid(), EmployeeId, state, timestamp, activityContext, note));
    }

    /// <summary>
    /// Korrigiert einen Eintrag, wenn die Policy dies erlaubt.
    /// </summary>
    public bool CorrectEntry(Guid entryId, DateTimeOffset correctedTimestamp, DateTimeOffset now, CorrectionWindowPolicy policy)
    {
        var entry = _entries.FirstOrDefault(x => x.Id == entryId);
        if (entry is null)
        {
            return false;
        }

        if (!policy.IsWithinWindow(entry.Timestamp, now))
        {
            return false;
        }

        var corrected = entry.WithTimestamp(correctedTimestamp);
        _entries.Remove(entry);
        _entries.Add(corrected);
        return true;
    }

    /// <summary>
    /// Ermittelt Lücken zwischen aufeinanderfolgenden Einträgen.
    /// </summary>
    public IReadOnlyList<Conflict> DetectGaps(TimeSpan maxGap)
    {
        if (_entries.Count < 2)
        {
            return Array.Empty<Conflict>();
        }

        var ordered = _entries.OrderBy(x => x.Timestamp).ToArray();
        var conflicts = new List<Conflict>();
        for (var i = 1; i < ordered.Length; i++)
        {
            var gap = ordered[i].Timestamp - ordered[i - 1].Timestamp;
            if (gap > maxGap)
            {
                conflicts.Add(new Conflict("GAP", $"Gap detected: {gap.TotalMinutes:F0} minutes between entries."));
            }
        }

        return conflicts;
    }

    /// <summary>
    /// Prüft, ob der Tag mit den aktuellen Pausenregeln abgeschlossen werden darf.
    /// </summary>
    public bool CanCloseDay(BreakPolicy breakPolicy)
    {
        if (_entries.Count == 0)
        {
            return false;
        }

        var ordered = _entries.OrderBy(x => x.Timestamp).ToArray();
        var hasEndOfDay = ordered.Any(x => x.Status == PresenceState.EndOfDay);
        if (!hasEndOfDay)
        {
            return false;
        }

        var first = ordered.First().Timestamp;
        var last = ordered.Last().Timestamp;
        var totalWorkedWindow = last - first;
        var breakMinutes = ordered.Count(x => x.Status == PresenceState.Break) * breakPolicy.MinimumBreakDuration.TotalMinutes;

        if (totalWorkedWindow >= breakPolicy.MandatoryBreakAfter && breakMinutes < breakPolicy.MinimumBreakDuration.TotalMinutes)
        {
            return false;
        }

        return true;
    }
}
