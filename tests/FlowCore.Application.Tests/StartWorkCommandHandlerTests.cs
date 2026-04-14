using Xunit;
using FlowCore.Application.Abstractions;
using FlowCore.Application.Commands;
using FlowCore.Domain;

namespace FlowCore.Application.Tests;

public sealed class StartWorkCommandHandlerTests
{
    [Fact]
    public void Handle_CreatesTimeEntryWithWorkStatus()
    {
        var clock = new FakeClock(new DateTimeOffset(2026, 1, 10, 8, 0, 0, TimeSpan.Zero));
        var sut = new StartWorkCommandHandler(clock);

        var entry = sut.Handle(new StartWorkCommand(Guid.NewGuid(), "Start"));

        Assert.Equal(PresenceState.Work, entry.Status);
        Assert.Equal(clock.UtcNow, entry.Timestamp);
    }

    private sealed class FakeClock : IClock
    {
        public FakeClock(DateTimeOffset utcNow)
        {
            UtcNow = utcNow;
        }

        public DateTimeOffset UtcNow { get; }
    }
}
