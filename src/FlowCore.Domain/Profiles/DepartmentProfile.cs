using FlowCore.Domain.Policies;

namespace FlowCore.Domain.Profiles;

/// <summary>
/// Abteilungsprofil mit zentralen Zeitregelwerken.
/// </summary>
public sealed class DepartmentProfile
{
    public DepartmentProfile(Guid id, string name, BreakPolicy breakPolicy, FlexTimeModel flexTimeModel, CorrectionWindowPolicy correctionWindowPolicy)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Department profile id must not be empty.", nameof(id));
        }

        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        Id = id;
        Name = name.Trim();
        BreakPolicy = breakPolicy;
        FlexTimeModel = flexTimeModel;
        CorrectionWindowPolicy = correctionWindowPolicy;
    }

    public Guid Id { get; }

    public string Name { get; }

    public BreakPolicy BreakPolicy { get; }

    public FlexTimeModel FlexTimeModel { get; }

    public CorrectionWindowPolicy CorrectionWindowPolicy { get; }
}
