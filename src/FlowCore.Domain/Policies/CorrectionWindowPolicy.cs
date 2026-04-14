namespace FlowCore.Domain.Policies;

/// <summary>
/// Bewertet, ob eine Korrektur innerhalb des erlaubten Zeitfensters liegt.
/// </summary>
public sealed class CorrectionWindowPolicy
{
    public CorrectionWindowPolicy(TimeSpan correctionWindow)
    {
        if (correctionWindow <= TimeSpan.Zero)
        {
            throw new ArgumentOutOfRangeException(nameof(correctionWindow));
        }

        CorrectionWindow = correctionWindow;
    }

    public TimeSpan CorrectionWindow { get; }

    /// <summary>
    /// Prüft, ob der Buchungszeitpunkt innerhalb des Korrekturfensters liegt.
    /// </summary>
    public bool IsWithinWindow(DateTimeOffset entryTimestamp, DateTimeOffset now)
    {
        return now >= entryTimestamp && now - entryTimestamp <= CorrectionWindow;
    }
}
