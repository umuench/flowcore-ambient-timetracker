namespace FlowCore.Client.ViewModels;

/// <summary>
/// ViewModel für den Korrekturdialog.
/// </summary>
public sealed class CorrectionDialogViewModel
{
    public Guid TimeEntryId { get; init; }

    public DateTimeOffset CurrentTimestamp { get; init; }

    public DateTimeOffset ProposedTimestamp { get; set; }

    public string Reason { get; set; } = string.Empty;
}
