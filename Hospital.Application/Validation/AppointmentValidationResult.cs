namespace Hospital.Application.Rules;

/// <summary>
/// Represents the results of applying one or more appointment rules. Includes success/failure and an optional list of error messages.
/// </summary>
public class AppointmentValidationResult(bool isSuccess, IReadOnlyList<string> errorMessage)
{
    public bool IsSuccess { get; private set; } = isSuccess;
    public IReadOnlyList<string> ErrorMessage { get; private set; } = errorMessage;

    public static AppointmentValidationResult Success() => new(true, []);
    public static AppointmentValidationResult Failure(IEnumerable<string> errors) => new (false, [.. errors]);
    public static AppointmentValidationResult Failure(string error) => new (false, [error]);
}
