using FlowCore.Application.Commands;

namespace FlowCore.Application.Validation;

/// <summary>
/// Validiert CorrectTimeEntryCommand.
/// </summary>
public sealed class CorrectTimeEntryCommandValidator
{
    public ValidationResult Validate(CorrectTimeEntryCommand command)
    {
        var errors = new List<string>();

        if (command.UserId == Guid.Empty)
        {
            errors.Add("UserId is required.");
        }

        if (command.TimeEntryId == Guid.Empty)
        {
            errors.Add("TimeEntryId is required.");
        }

        if (string.IsNullOrWhiteSpace(command.Reason))
        {
            errors.Add("Reason is required.");
        }

        return errors.Count == 0 ? ValidationResult.Success() : ValidationResult.Failure(errors.ToArray());
    }
}
