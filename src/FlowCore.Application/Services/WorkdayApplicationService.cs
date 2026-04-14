using FlowCore.Application.Abstractions;
using FlowCore.Application.Commands;
using FlowCore.Contracts.Realtime;
using FlowCore.Domain;
using FlowCore.Domain.Approvals;
using FlowCore.Domain.Conflicts;
using FlowCore.Domain.TimeEntries;
using FlowCore.Domain.ValueObjects;

namespace FlowCore.Application.Services;

/// <summary>
/// Orchestriert die Kern-Use-Cases für den Arbeitstag.
/// </summary>
public sealed class WorkdayApplicationService
{
    private readonly IClock _clock;
    private readonly IWorkdayRepository _workdayRepository;
    private readonly IPolicyProvider _policyProvider;
    private readonly IApprovalRequestRepository _approvalRequestRepository;
    private readonly IDomainEventPublisher _eventPublisher;

    public WorkdayApplicationService(
        IClock clock,
        IWorkdayRepository workdayRepository,
        IPolicyProvider policyProvider,
        IApprovalRequestRepository approvalRequestRepository,
        IDomainEventPublisher eventPublisher)
    {
        _clock = clock;
        _workdayRepository = workdayRepository;
        _policyProvider = policyProvider;
        _approvalRequestRepository = approvalRequestRepository;
        _eventPublisher = eventPublisher;
    }

    /// <summary>
    /// Erfasst den Arbeitsbeginn.
    /// </summary>
    public async Task<TimeEntry> StartWorkAsync(StartWorkCommand command, CancellationToken cancellationToken)
    {
        var workday = await GetTodayWorkdayAsync(command.UserId, cancellationToken);
        workday.AddEntry(PresenceState.Work, _clock.UtcNow, note: command.Note);
        await _workdayRepository.SaveAsync(workday, cancellationToken);
        var created = workday.Entries.OrderBy(x => x.Timestamp).Last();
        await PublishPresenceChangedAsync(command.UserId, PresenceState.Work, created.Timestamp, cancellationToken);
        return created;
    }

    /// <summary>
    /// Erfasst das Arbeitsende.
    /// </summary>
    public async Task<TimeEntry> EndWorkAsync(EndWorkdayCommand command, CancellationToken cancellationToken)
    {
        var workday = await GetTodayWorkdayAsync(command.UserId, cancellationToken);
        workday.AddEntry(PresenceState.EndOfDay, _clock.UtcNow, note: command.Note);
        await _workdayRepository.SaveAsync(workday, cancellationToken);
        var created = workday.Entries.OrderBy(x => x.Timestamp).Last();
        await PublishPresenceChangedAsync(command.UserId, PresenceState.EndOfDay, created.Timestamp, cancellationToken);
        return created;
    }

    /// <summary>
    /// Startet eine Pause.
    /// </summary>
    public async Task<TimeEntry> StartBreakAsync(StartBreakCommand command, CancellationToken cancellationToken)
    {
        var workday = await GetTodayWorkdayAsync(command.UserId, cancellationToken);
        workday.AddEntry(PresenceState.Break, _clock.UtcNow, note: command.Note);
        await _workdayRepository.SaveAsync(workday, cancellationToken);
        var created = workday.Entries.OrderBy(x => x.Timestamp).Last();
        await PublishPresenceChangedAsync(command.UserId, PresenceState.Break, created.Timestamp, cancellationToken);
        return created;
    }

    /// <summary>
    /// Beendet eine Pause.
    /// </summary>
    public async Task<TimeEntry> EndBreakAsync(EndBreakCommand command, CancellationToken cancellationToken)
    {
        var workday = await GetTodayWorkdayAsync(command.UserId, cancellationToken);
        workday.AddEntry(PresenceState.Work, _clock.UtcNow, note: command.Note);
        await _workdayRepository.SaveAsync(workday, cancellationToken);
        var created = workday.Entries.OrderBy(x => x.Timestamp).Last();
        await PublishPresenceChangedAsync(command.UserId, PresenceState.Work, created.Timestamp, cancellationToken);
        return created;
    }

    /// <summary>
    /// Wechselt den Präsenzzustand.
    /// </summary>
    public async Task<TimeEntry> ChangePresenceAsync(ChangePresenceStateCommand command, CancellationToken cancellationToken)
    {
        var workday = await GetTodayWorkdayAsync(command.UserId, cancellationToken);
        workday.AddEntry(command.PresenceState, _clock.UtcNow, note: command.Note);
        await _workdayRepository.SaveAsync(workday, cancellationToken);
        var created = workday.Entries.OrderBy(x => x.Timestamp).Last();
        await PublishPresenceChangedAsync(command.UserId, command.PresenceState, created.Timestamp, cancellationToken);
        return created;
    }

    /// <summary>
    /// Wechselt den Aktivitätskontext für die aktuelle Präsenz.
    /// </summary>
    public async Task<TimeEntry> ChangeActivityAsync(ChangeActivityContextCommand command, CancellationToken cancellationToken)
    {
        var workday = await GetTodayWorkdayAsync(command.UserId, cancellationToken);
        var activity = new ActivityContext(command.ProjectKey, command.Activity);
        workday.AddEntry(workday.CurrentState, _clock.UtcNow, activity, command.Note);
        await _workdayRepository.SaveAsync(workday, cancellationToken);
        return workday.Entries.OrderBy(x => x.Timestamp).Last();
    }

    /// <summary>
    /// Korrigiert einen Zeiteintrag oder erzeugt eine Genehmigungsanfrage.
    /// </summary>
    public async Task<CorrectTimeEntryResult> CorrectTimeEntryAsync(CorrectTimeEntryCommand command, CancellationToken cancellationToken)
    {
        var workday = await GetTodayWorkdayAsync(command.UserId, cancellationToken);
        var correctionPolicy = await _policyProvider.GetCorrectionWindowPolicyAsync(command.UserId, cancellationToken);
        var corrected = workday.CorrectEntry(command.TimeEntryId, command.CorrectedTimestamp, _clock.UtcNow, correctionPolicy);

        if (corrected)
        {
            await _workdayRepository.SaveAsync(workday, cancellationToken);
            return CorrectTimeEntryResult.Corrected();
        }

        var approval = new ApprovalRequest(Guid.NewGuid(), command.UserId, command.Reason, _clock.UtcNow);
        await _approvalRequestRepository.SaveAsync(approval, cancellationToken);
        await _eventPublisher.PublishAsync(new ApprovalRequestedEvent(approval.Id, command.UserId, command.Reason, approval.RequestedAt), cancellationToken);
        return CorrectTimeEntryResult.ApprovalRequired(approval.Id);
    }

    /// <summary>
    /// Ermittelt Konflikte für einen Arbeitstag.
    /// </summary>
    public async Task<IReadOnlyList<Conflict>> DetectConflictsAsync(Guid userId, DateOnly date, CancellationToken cancellationToken)
    {
        var workday = await _workdayRepository.GetOrCreateAsync(userId, date, cancellationToken);
        var conflicts = workday.DetectGaps(TimeSpan.FromMinutes(45));
        if (conflicts.Count > 0)
        {
            await _eventPublisher.PublishAsync(new ConflictHintEvent(userId, conflicts.Count, _clock.UtcNow), cancellationToken);
        }

        return conflicts;
    }

    /// <summary>
    /// Prüft, ob ein Arbeitstag abgeschlossen werden darf.
    /// </summary>
    public async Task<bool> ValidateDayClosureAsync(Guid userId, DateOnly date, CancellationToken cancellationToken)
    {
        var workday = await _workdayRepository.GetOrCreateAsync(userId, date, cancellationToken);
        var breakPolicy = await _policyProvider.GetBreakPolicyAsync(userId, cancellationToken);
        return workday.CanCloseDay(breakPolicy);
    }

    private Task<Domain.Workdays.Workday> GetTodayWorkdayAsync(Guid userId, CancellationToken cancellationToken)
    {
        return _workdayRepository.GetOrCreateAsync(userId, DateOnly.FromDateTime(_clock.UtcNow.UtcDateTime), cancellationToken);
    }

    private Task PublishPresenceChangedAsync(Guid userId, PresenceState state, DateTimeOffset changedAt, CancellationToken cancellationToken)
    {
        return _eventPublisher.PublishAsync(new PresenceChangedEvent(userId, state.ToString(), changedAt), cancellationToken);
    }
}
