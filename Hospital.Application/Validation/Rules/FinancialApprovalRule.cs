using Hospital.Application.Appointments;

namespace Hospital.Application.Validation.Rules;

/// <summary>
/// Validates that an appointment has a valid financial approval.
/// </summary>
public class FinancialApprovalRule : IAppointmentRule
{
    public string ErrorMessage => "Procedures for this department may require financial approval.";

    public async Task<bool> IsSatisfiedAsync(AppointmentRequestInfo appointmentInfo)
    {
        return await Task.FromResult(HasValidFinancialApproval(appointmentInfo.Cpr, appointmentInfo.Department));
    }

    private static bool HasValidFinancialApproval(string cpr, string department)
    {
        Console.WriteLine($"[LOG] Checking if financial approval exists for CPR {cpr} in {department}");
        return true; // Dummy check (To be replaced later)
    }
}
