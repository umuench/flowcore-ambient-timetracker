using FlowCore.Client.Context;
using FlowCore.Domain;

namespace FlowCore.Client.Ui;

/// <summary>
/// Laufzeitstatus der Client-Shell.
/// </summary>
public sealed record ClientUiState(
    ClientUiDensity Density,
    PresenceState PresenceState,
    InteractionContext? ActiveContext,
    InteractionContext? LastInteractionContext,
    bool IsVisible,
    bool UseFadeTransitions);
