using Hospital.Application.Appointments;

namespace Hospital.Application.Validation.Rules;

/// <summary>
/// Represents a business rule that must be satisfied in order to schedule an appointment.
/// </summary>
public interface IAppointmentRule
{
    string ErrorMessage { get; }
    
    /// <summary>
    /// Evaluates whether the rule is satisfied for the passed appointment request.
    /// </summary>
    Task<bool> IsSatisfiedAsync(AppointmentRequestInfo appointmentInfo);
}