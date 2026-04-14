namespace FlowCore.Infrastructure.Persistence.Entities;

/// <summary>
/// Persistenzmodell für ApprovalRequest.
/// </summary>
public sealed class ApprovalRequestEntity
{
    public Guid Id { get; set; }

    public Guid EmployeeId { get; set; }

    public string Reason { get; set; } = string.Empty;

    public DateTimeOffset RequestedAt { get; set; }
}
