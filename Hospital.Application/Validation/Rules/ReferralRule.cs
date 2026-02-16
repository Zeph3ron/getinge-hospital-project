using Hospital.Application.Appointments;

namespace Hospital.Application.Validation.Rules;

/// <summary>
/// Validates that an appointment has a valid referral.
/// </summary>
public class ReferralRule : IAppointmentRule
{
    public string ErrorMessage => "This department requires a valid referral.";

    public async Task<bool> IsSatisfiedAsync(AppointmentRequestInfo appointmentInfo)
    {
        return await Task.FromResult(HasValidReferral(appointmentInfo.Cpr, appointmentInfo.Department));
    }

    private static bool HasValidReferral(string cpr, string department)
    {
        Console.WriteLine($"[LOG] Checking if referral exists for CPR {cpr} in {department}");
        return true; // Dummy check (To be replaced later)
    }
}