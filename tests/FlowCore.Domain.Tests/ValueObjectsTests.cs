using FlowCore.Domain.ValueObjects;
using Xunit;

namespace FlowCore.Domain.Tests;

public sealed class ValueObjectsTests
{
    [Fact]
    public void TimeRange_Throws_WhenEndBeforeStart()
    {
        var start = DateTimeOffset.UtcNow;
        var end = start.AddMinutes(-1);

        Assert.Throws<ArgumentOutOfRangeException>(() => new TimeRange(start, end));
    }

    [Fact]
    public void ActivityContext_TrimsValues()
    {
        var context = new ActivityContext(" PRJ-1 ", " Coding ");

        Assert.Equal("PRJ-1", context.ProjectKey);
        Assert.Equal("Coding", context.Activity);
    }
}
