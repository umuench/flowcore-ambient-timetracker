namespace FlowCore.Application.Services;

/// <summary>
/// Ergebnis einer Zeitkorrektur.
/// </summary>
public sealed class CorrectTimeEntryResult
{
    private CorrectTimeEntryResult(bool wasCorrected, bool requiresApproval, Guid? approvalRequestId)
    {
        WasCorrected = wasCorrected;
        RequiresApproval = requiresApproval;
        ApprovalRequestId = approvalRequestId;
    }

    public bool WasCorrected { get; }

    public bool RequiresApproval { get; }

    public Guid? ApprovalRequestId { get; }

    public static CorrectTimeEntryResult Corrected() => new(true, false, null);

    public static CorrectTimeEntryResult ApprovalRequired(Guid approvalRequestId) => new(false, true, approvalRequestId);
}
