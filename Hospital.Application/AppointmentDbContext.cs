using Hospital.Application.Appointments;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Application;

public class AppointmentDbContext(DbContextOptions<AppointmentDbContext> options) : DbContext(options)
{
    public DbSet<Appointment> Appointments { get; set; }
}