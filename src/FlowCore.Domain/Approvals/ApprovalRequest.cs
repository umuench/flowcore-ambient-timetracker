namespace FlowCore.Domain.Approvals;

/// <summary>
/// Repräsentiert eine genehmigungspflichtige Aktion außerhalb der Policy.
/// </summary>
public sealed class ApprovalRequest
{
    public ApprovalRequest(Guid id, Guid employeeId, string reason, DateTimeOffset requestedAt)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Approval request id must not be empty.", nameof(id));
        }

        if (employeeId == Guid.Empty)
        {
            throw new ArgumentException("Employee id must not be empty.", nameof(employeeId));
        }

        ArgumentException.ThrowIfNullOrWhiteSpace(reason);

        Id = id;
        EmployeeId = employeeId;
        Reason = reason.Trim();
        RequestedAt = requestedAt;
    }

    public Guid Id { get; }

    public Guid EmployeeId { get; }

    public string Reason { get; }

    public DateTimeOffset RequestedAt { get; }
}
