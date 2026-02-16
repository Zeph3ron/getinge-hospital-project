namespace Hospital.WebApi.Models;

public record AppointmentRequest(string Cpr, string PatientName, DateTime AppointmentDate, string Department, string DoctorName);
