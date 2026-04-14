using FlowCore.Client.Context;
using FlowCore.Client.Ui;
using FlowCore.Domain;
using Xunit;

namespace FlowCore.Architecture.Tests;

public sealed class ClientUiStateMachineTests
{
    [Fact]
    public void ActivateCompact_SetsDensityAndContext()
    {
        var context = new InteractionContext("Monitor-1", 120, 80, "Visual Studio", DateTimeOffset.UtcNow);
        var sut = new ClientUiStateMachine();

        sut.ActivateCompact(context);

        Assert.Equal(ClientUiDensity.Compact, sut.Current.Density);
        Assert.True(sut.Current.IsVisible);
        Assert.Equal("Monitor-1", sut.Current.ActiveContext?.MonitorId);
    }

    [Fact]
    public void GoDormant_ClearsActiveContext_ButKeepsLastContext()
    {
        var context = new InteractionContext("Monitor-2", 512, 144, "Browser", DateTimeOffset.UtcNow);
        var sut = new ClientUiStateMachine();
        sut.OpenFocus(context);

        sut.GoDormant();

        Assert.Equal(ClientUiDensity.Dormant, sut.Current.Density);
        Assert.False(sut.Current.IsVisible);
        Assert.Null(sut.Current.ActiveContext);
        Assert.Equal("Monitor-2", sut.Current.LastInteractionContext?.MonitorId);
    }

    [Fact]
    public void SetPresenceState_UpdatesState()
    {
        var sut = new ClientUiStateMachine();

        sut.SetPresenceState(PresenceState.Break);

        Assert.Equal(PresenceState.Break, sut.Current.PresenceState);
    }
}
