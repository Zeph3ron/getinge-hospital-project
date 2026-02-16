namespace Hospital.Application.Appointments;

public class Appointment
{
    public int Id { get; set; }
    public required string Cpr { get; init; }
    public required string PatientName { get; init; }
    public DateTime AppointmentDate { get; set; }
    public required string Department { get; set; }
    public required string DoctorName { get; set; }
}