namespace FlowCore.Domain.Employees;

/// <summary>
/// Repräsentiert einen Mitarbeitenden in FlowCore.
/// </summary>
public sealed class Employee
{
    public Employee(Guid id, string displayName, Guid departmentProfileId)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Employee id must not be empty.", nameof(id));
        }

        ArgumentException.ThrowIfNullOrWhiteSpace(displayName);

        Id = id;
        DisplayName = displayName.Trim();
        DepartmentProfileId = departmentProfileId;
    }

    public Guid Id { get; }

    public string DisplayName { get; }

    public Guid DepartmentProfileId { get; }
}
