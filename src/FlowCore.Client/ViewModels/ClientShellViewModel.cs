using FlowCore.Client.Context;
using FlowCore.Client.Ui;
using FlowCore.Domain;

namespace FlowCore.Client.ViewModels;

/// <summary>
/// Kompositions-ViewModel der FlowCore-Client-Shell.
/// </summary>
public sealed class ClientShellViewModel
{
    private readonly ClientUiStateMachine _stateMachine;

    /// <summary>
    /// Initialisiert das Shell-ViewModel.
    /// </summary>
    public ClientShellViewModel(ClientUiStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
        PresenceDot = new PresenceDotViewModel();
        StatusTiles = Enum.GetValues<PresenceState>()
            .Select(state => new StatusTileViewModel(state, state.ToString(), string.Empty))
            .ToArray();
    }

    public PresenceDotViewModel PresenceDot { get; }

    public IReadOnlyList<StatusTileViewModel> StatusTiles { get; }

    public ClientUiState CurrentUiState => _stateMachine.Current;

    /// <summary>
    /// Zeigt die kompakte Oberfläche.
    /// </summary>
    public void ShowCompact(InteractionContext context)
    {
        _stateMachine.ActivateCompact(context);
    }

    /// <summary>
    /// Zeigt die Fokusoberfläche.
    /// </summary>
    public void ShowFocus(InteractionContext context)
    {
        _stateMachine.OpenFocus(context);
    }

    /// <summary>
    /// Blendet die Oberfläche in den Dormant-Modus aus.
    /// </summary>
    public void HideToDormant()
    {
        _stateMachine.GoDormant();
    }

    /// <summary>
    /// Wechselt den Präsenzzustand im UI.
    /// </summary>
    public void SwitchPresence(PresenceState state)
    {
        PresenceDot.SetState(state);
        _stateMachine.SetPresenceState(state);
    }
}
