using FlowCore.Application.Commands;

namespace FlowCore.Application.Validation;

/// <summary>
/// Validiert StartWorkCommand.
/// </summary>
public sealed class StartWorkCommandValidator
{
    public ValidationResult Validate(StartWorkCommand command)
    {
        if (command.UserId == Guid.Empty)
        {
            return ValidationResult.Failure("UserId is required.");
        }

        return ValidationResult.Success();
    }
}
