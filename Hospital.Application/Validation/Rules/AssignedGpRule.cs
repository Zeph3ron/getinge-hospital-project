using Hospital.Application.Appointments;

namespace Hospital.Application.Validation.Rules;

/// <summary>
/// Validates that the patient is assigned to the appointments GP.
/// </summary>
public class AssignedGpRule : IAppointmentRule
{
    public string ErrorMessage => "The selected doctor must be the patient's assigned GP.";

    public async Task<bool> IsSatisfiedAsync(AppointmentRequestInfo appointmentInfo)
    {
        return await Task.FromResult(IsAssignedToGP(appointmentInfo.Cpr, appointmentInfo.DoctorName));
    }

    private static bool IsAssignedToGP(string cpr, string doctorName)
    {
        Console.WriteLine($"[LOG] Validating assigned GP for CPR '{cpr}' with doctor {doctorName}.");
        return true; // Dummy check (To be implemented later)
    }
}