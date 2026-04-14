using FlowCore.Client.Context;
using FlowCore.Domain;

namespace FlowCore.Client.Ui;

/// <summary>
/// Zustandsmaschine für Dormant/Compact/Focus mit Kontextanker.
/// </summary>
public sealed class ClientUiStateMachine
{
    private ClientUiState _state = new(
        ClientUiDensity.Dormant,
        PresenceState.Work,
        null,
        null,
        IsVisible: false,
        UseFadeTransitions: true);

    public ClientUiState Current => _state;

    /// <summary>
    /// Aktiviert die kompakte Darstellung am aktuellen Kontext.
    /// </summary>
    public void ActivateCompact(InteractionContext context)
    {
        _state = _state with
        {
            Density = ClientUiDensity.Compact,
            ActiveContext = context,
            LastInteractionContext = context,
            IsVisible = true,
        };
    }

    /// <summary>
    /// Öffnet die Fokusdarstellung.
    /// </summary>
    public void OpenFocus(InteractionContext context)
    {
        _state = _state with
        {
            Density = ClientUiDensity.Focus,
            ActiveContext = context,
            LastInteractionContext = context,
            IsVisible = true,
        };
    }

    /// <summary>
    /// Kehrt aus Fokus in die kompakte Darstellung zurück.
    /// </summary>
    public void ReturnToCompact()
    {
        _state = _state with
        {
            Density = ClientUiDensity.Compact,
            ActiveContext = _state.LastInteractionContext,
            IsVisible = true,
        };
    }

    /// <summary>
    /// Wechselt in den ruhigen Dormant-Modus.
    /// </summary>
    public void GoDormant()
    {
        _state = _state with
        {
            Density = ClientUiDensity.Dormant,
            ActiveContext = null,
            IsVisible = false,
        };
    }

    /// <summary>
    /// Setzt den aktuellen Präsenzzustand.
    /// </summary>
    public void SetPresenceState(PresenceState presenceState)
    {
        _state = _state with { PresenceState = presenceState };
    }
}
