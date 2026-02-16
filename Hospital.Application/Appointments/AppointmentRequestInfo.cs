namespace Hospital.Application.Appointments;

public record AppointmentRequestInfo
{
    public string Cpr { get; init; } = default!;
    public string PatientName { get; init; } = default!;
    public DateTime AppointmentDate { get; init; } = default!;
    public string Department { get; init; } = default!;
    public string DoctorName { get; init; } = default!;
}