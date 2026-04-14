namespace FlowCore.Application.Validation;

/// <summary>
/// Ergebnis einer einfachen Command-Validierung.
/// </summary>
public sealed class ValidationResult
{
    private ValidationResult(bool isValid, string[] errors)
    {
        IsValid = isValid;
        Errors = errors;
    }

    public bool IsValid { get; }

    public IReadOnlyList<string> Errors { get; }

    public static ValidationResult Success() => new(true, Array.Empty<string>());

    public static ValidationResult Failure(params string[] errors) => new(false, errors);
}
