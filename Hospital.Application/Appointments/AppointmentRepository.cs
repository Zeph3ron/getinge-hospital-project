namespace Hospital.Application.Appointments;

public class AppointmentRepository(AppointmentDbContext dbContext)
{
    public async Task AddAsync(Appointment appointment)
    {
        dbContext.Appointments.Add(appointment);
        await dbContext.SaveChangesAsync();
    }
}