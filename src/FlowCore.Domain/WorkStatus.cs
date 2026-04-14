namespace FlowCore.Domain;

/// <summary>
/// Kompatibilitätsalias zu <see cref="PresenceState"/>.
/// </summary>
public enum WorkStatus
{
    Work = PresenceState.Work,
    Sync = PresenceState.Sync,
    ShortAway = PresenceState.ShortAway,
    OutOfOffice = PresenceState.OutOfOffice,
    Break = PresenceState.Break,
    EndOfDay = PresenceState.EndOfDay,
}
