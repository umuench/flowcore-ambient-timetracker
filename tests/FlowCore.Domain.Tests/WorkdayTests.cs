using Xunit;
using FlowCore.Domain;
using FlowCore.Domain.Policies;
using FlowCore.Domain.Workdays;

namespace FlowCore.Domain.Tests;

public sealed class WorkdayTests
{
    [Fact]
    public void DetectGaps_ReturnsConflict_WhenGapIsTooLarge()
    {
        var workday = new Workday(Guid.NewGuid(), Guid.NewGuid(), new DateOnly(2026, 1, 12));
        var start = new DateTimeOffset(2026, 1, 12, 8, 0, 0, TimeSpan.Zero);
        workday.AddEntry(PresenceState.Work, start);
        workday.AddEntry(PresenceState.Sync, start.AddHours(2));

        var conflicts = workday.DetectGaps(TimeSpan.FromMinutes(30));

        Assert.Single(conflicts);
        Assert.Equal("GAP", conflicts[0].Code);
    }

    [Fact]
    public void CorrectEntry_ReturnsFalse_WhenOutsideCorrectionWindow()
    {
        var workday = new Workday(Guid.NewGuid(), Guid.NewGuid(), new DateOnly(2026, 1, 12));
        var timestamp = new DateTimeOffset(2026, 1, 12, 8, 0, 0, TimeSpan.Zero);
        workday.AddEntry(PresenceState.Work, timestamp);
        var entryId = workday.Entries.Single().Id;

        var policy = new CorrectionWindowPolicy(TimeSpan.FromHours(1));
        var result = workday.CorrectEntry(entryId, timestamp.AddMinutes(5), timestamp.AddHours(2), policy);

        Assert.False(result);
    }

    [Fact]
    public void CanCloseDay_ReturnsTrue_WhenEndOfDayAndBreakRequirementSatisfied()
    {
        var workday = new Workday(Guid.NewGuid(), Guid.NewGuid(), new DateOnly(2026, 1, 12));
        var start = new DateTimeOffset(2026, 1, 12, 8, 0, 0, TimeSpan.Zero);
        workday.AddEntry(PresenceState.Work, start);
        workday.AddEntry(PresenceState.Break, start.AddHours(6));
        workday.AddEntry(PresenceState.EndOfDay, start.AddHours(8));

        var breakPolicy = new BreakPolicy(TimeSpan.FromHours(6), TimeSpan.FromMinutes(30));

        var canClose = workday.CanCloseDay(breakPolicy);

        Assert.True(canClose);
    }
}
