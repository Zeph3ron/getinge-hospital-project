using Hospital.Application.Appointments;
using Hospital.Application.Validation.Rules;

namespace Hospital.Application.Departments;

/// <summary>
/// Represents a department in a hospital and the set of rules that must be met
/// in order to schedule an appointment.
/// </summary>
public class Department(string name, IEnumerable<IAppointmentRule> rules)
{
    public string Name { get; } = name;
    private IReadOnlyCollection<IAppointmentRule> _rules { get; } = [.. rules];

    /// <summary>
    /// Validates the appointment request against all configured rules for this department.
    /// Returns a list of error messages (empty list = success).
    /// </summary>
    public async Task<IReadOnlyList<string>> ValidateAsync(AppointmentRequestInfo appointmentInfo)
    {
        var errors = new List<string>();
        foreach (var rule in _rules)
        {
            var isSatisfied = await rule.IsSatisfiedAsync(appointmentInfo);
            if (!isSatisfied)
            {
                errors.Add(rule.ErrorMessage);
            }
        }
        return errors;
    }
}