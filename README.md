# getinge-hospital-project
Hospital appointment scheduling API built with .NET 8.

# Hospital Appointment Scheduling

## Overview

This project is a conceptual redesign of a hospital appointment scheduling system.

The purpose of the exercise is to demonstrate:

- Clean architecture principles
- Extensible design for department-specific appointment rules
- Separation of concerns
- Proper dependency injection
- Maintainable and modular structure

The implementation allows new departments and their specific appointment rules to be added without modifying the core `AppointmentService`.

---

## Tech Stack

- .NET 8
- ASP.NET Core Minimal API
- Entity Framework Core (InMemory provider)
- Built-in Dependency Injection

---

## Prerequisites

- .NET 8 SDK installed  
  https://dotnet.microsoft.com/download

Verify installation:

```bash
dotnet --version
```

---

## Running the Application

From the solution root:

```bash
dotnet restore
dotnet build
cd Hospital.WebApi
dotnet run
```

The API will start on a local HTTP port (shown in the console output), typically:

```
http://localhost:5082
```

---

## API Endpoint

### Create Appointment

**POST** `/appointments`

### Example Request Body

```json
{
  "cpr": "123456-7890",
  "patientName": "John Doe",
  "appointmentDate": "2026-03-01T10:00:00Z",
  "department": "Radiology",
  "doctorName": "Dr. Smith"
}
```

### Example Using curl

```bash
curl -X POST https://localhost:5082/appointments \
-H "Content-Type: application/json" \
-d '{
  "cpr": "123456-7890",
  "patientName": "John Doe",
  "appointmentDate": "2026-03-01T10:00:00Z",
  "department": "Radiology",
  "doctorName": "Dr. Smith"
}'
```

---

## Extending the System

To add a new department:

1. Implement department-specific appointment rules (if any).
2. Register the department in `DepartmentConfiguration`.
3. ...
4. PROFIT!

---
