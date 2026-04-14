using FlowCore.Domain;

namespace FlowCore.Client.ViewModels;

/// <summary>
/// ViewModel einer Status-Kachel in der Compact-Dichte.
/// </summary>
public sealed record StatusTileViewModel(PresenceState State, string Title, string Shortcut);
