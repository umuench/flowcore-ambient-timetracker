using FlowCore.Application.Abstractions;
using FlowCore.Domain;
using FlowCore.Domain.TimeEntries;

namespace FlowCore.Application.Commands;

/// <summary>
/// Verarbeitet den Start des Arbeitstags als Zeitbuchung.
/// </summary>
public sealed class StartWorkCommandHandler
{
    private readonly IClock _clock;

    /// <summary>
    /// Initialisiert den Handler.
    /// </summary>
    public StartWorkCommandHandler(IClock clock)
    {
        _clock = clock;
    }

    /// <summary>
    /// Erzeugt den Zeiteintrag für den Arbeitsbeginn.
    /// </summary>
    public TimeEntry Handle(StartWorkCommand command)
    {
        return new TimeEntry(Guid.NewGuid(), command.UserId, PresenceState.Work, _clock.UtcNow, note: command.Note);
    }
}
