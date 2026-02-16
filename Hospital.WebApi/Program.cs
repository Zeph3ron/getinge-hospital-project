using Hospital.Application;
using Hospital.Application.Appointments;
using Hospital.Application.Departments;
using Hospital.WebApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppointmentDbContext>(options =>
    options.UseInMemoryDatabase("HospitalDb"));
builder.Services.AddScoped<AppointmentRepository>();
builder.Services.AddScoped<AppointmentService>();
builder.Services.AddHttpClient<INationalRegistryService, NationalRegistryService>();

// Creates and adds departments to the registry 
builder.Services.AddSingleton(sp =>
{
   var departments = DepartmentConfiguration.CreateDepartments();
   return new DepartmentRegistry(departments); 
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapPost("/appointments", async (AppointmentRequest request, AppointmentService appointmentService) =>
{
    if(!IsValid(request))
        return Results.BadRequest("Invalid appointment request.");

    var appointmentRequestInfo = new AppointmentRequestInfo()
    {
        Cpr = request.Cpr,
        PatientName = request.PatientName,
        AppointmentDate = request.AppointmentDate,
        Department = request.Department,
        DoctorName = request.DoctorName
    };

    var result = await appointmentService.ScheduleAppointmentAsync(appointmentRequestInfo);
    return result.IsSuccess 
        ? Results.Ok("Appointment scheduled successfully.") 
        : Results.BadRequest(result.ErrorMessage);
});

// Helper method for validating an appointment request
static bool IsValid(AppointmentRequest request) =>
    !string.IsNullOrWhiteSpace(request.Cpr) &&
    !string.IsNullOrWhiteSpace(request.Department) &&
    !string.IsNullOrWhiteSpace(request.DoctorName) &&
    request.AppointmentDate > DateTime.UtcNow;

app.Run();
