using Hospital.Application.Departments;
using Hospital.Application.Rules;

namespace Hospital.Application.Appointments;

public class AppointmentService(AppointmentRepository repository, DepartmentRegistry departmentRegistry, INationalRegistryService nationalRegistry)
{
    public async Task<AppointmentValidationResult> ScheduleAppointmentAsync(AppointmentRequestInfo appointmentRequestInfo)
    {
        // 1. First validates patients CPR
        var isValidCpr = await nationalRegistry.ValidateCpr(appointmentRequestInfo.Cpr);
        if (!isValidCpr)
        {
            return AppointmentValidationResult.Failure("Invalid CPR number.");
        }

        // 2. Validates that department exists
        if(!departmentRegistry.TryGet(appointmentRequestInfo.Department, out var department))
        {
            return AppointmentValidationResult.Failure("Unknown department.");
        }

        // 3. Validates department rules
        var errors = await department.ValidateAsync(appointmentRequestInfo);
        if (errors.Count > 0)
        {
            return AppointmentValidationResult.Failure(errors);
        }

        // 4. Persists appointment in db
        var appointment = new Appointment
        {
            Cpr = appointmentRequestInfo.Cpr,
            PatientName = appointmentRequestInfo.PatientName,
            AppointmentDate = appointmentRequestInfo.AppointmentDate,
            Department = appointmentRequestInfo.Department,
            DoctorName = appointmentRequestInfo.DoctorName
        };

        await repository.AddAsync(appointment);
        
        return AppointmentValidationResult.Success();
    }
}