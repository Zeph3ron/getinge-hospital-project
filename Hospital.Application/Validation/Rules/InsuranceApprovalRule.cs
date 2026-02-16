using Hospital.Application.Appointments;

namespace Hospital.Application.Validation.Rules;

/// <summary>
/// Validates that an appointment has a valid insurance approval.
/// </summary>
public class InsuranceApprovalRule : IAppointmentRule
{
    public string ErrorMessage => "This department requires valid insurance approval.";

    public async Task<bool> IsSatisfiedAsync(AppointmentRequestInfo appointmentInfo)
    {
        return await Task.FromResult(HasValidInsuranceApproval(appointmentInfo.Cpr, appointmentInfo.Department));
    }

    private static bool HasValidInsuranceApproval(string cpr, string department)
    {
        Console.WriteLine($"[LOG] Checking if insurance approval exists for CPR {cpr} in {department}");
        return true; // Dummy check (To be replaced later)
    }
}