namespace FlowCore.Domain;

/// <summary>
/// Explizite Präsenzzustände der FlowCore-Domäne.
/// </summary>
public enum PresenceState
{
    Work = 1,
    Sync = 2,
    ShortAway = 3,
    OutOfOffice = 4,
    Break = 5,
    EndOfDay = 6,
}
