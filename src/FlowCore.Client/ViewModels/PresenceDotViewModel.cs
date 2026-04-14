using FlowCore.Domain;

namespace FlowCore.Client.ViewModels;

/// <summary>
/// ViewModel für den Präsenzpunkt.
/// </summary>
public sealed class PresenceDotViewModel
{
    public PresenceState CurrentState { get; private set; } = PresenceState.Work;

    public string Label => CurrentState.ToString();

    /// <summary>
    /// Setzt den anzuzeigenden Präsenzzustand.
    /// </summary>
    public void SetState(PresenceState state)
    {
        CurrentState = state;
    }
}
