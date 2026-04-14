using FlowCore.Domain.Conflicts;
using FlowCore.Domain.Workdays;

namespace FlowCore.Domain.Services;

/// <summary>
/// Kapselt Konflikterkennung für Tagesdaten.
/// </summary>
public sealed class ConflictDetector
{
    public IReadOnlyList<Conflict> Detect(Workday workday, TimeSpan maxGap)
    {
        return workday.DetectGaps(maxGap);
    }
}
