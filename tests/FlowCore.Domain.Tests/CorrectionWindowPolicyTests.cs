using Xunit;
using FlowCore.Domain.Policies;

namespace FlowCore.Domain.Tests;

public sealed class CorrectionWindowPolicyTests
{
    [Fact]
    public void IsWithinWindow_ReturnsTrue_WhenTimestampWithinRange()
    {
        var policy = new CorrectionWindowPolicy(TimeSpan.FromHours(12));
        var entryTime = DateTimeOffset.UtcNow.AddHours(-2);

        var result = policy.IsWithinWindow(entryTime, DateTimeOffset.UtcNow);

        Assert.True(result);
    }

    [Fact]
    public void IsWithinWindow_ReturnsFalse_WhenTimestampOutsideRange()
    {
        var policy = new CorrectionWindowPolicy(TimeSpan.FromHours(1));
        var entryTime = DateTimeOffset.UtcNow.AddHours(-2);

        var result = policy.IsWithinWindow(entryTime, DateTimeOffset.UtcNow);

        Assert.False(result);
    }
}
