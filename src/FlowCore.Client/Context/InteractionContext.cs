namespace FlowCore.Client.Context;

/// <summary>
/// Beschreibt den aktuellen Nutzungskontext für die UI-Verankerung.
/// </summary>
public sealed record InteractionContext(
    string MonitorId,
    int PointerX,
    int PointerY,
    string? ActiveWindowTitle,
    DateTimeOffset CapturedAtUtc);
