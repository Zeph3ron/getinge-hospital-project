using Hospital.Application.Validation.Rules;

namespace Hospital.Application.Departments;

/// <summary>
/// Static class thats responsible for assembling departments and wiring them together with their rules.
/// </summary>
public static class DepartmentConfiguration
{
    public static IEnumerable<Department> CreateDepartments()
    {
        return
        [
            new Department(
                "General Practice", 
                [
                    new AssignedGpRule()
                ]),

            new Department(
                "Physiotherapy", 
                [
                    new ReferralRule(),
                    new InsuranceApprovalRule()
                ]),
            
            new Department(
                "Surgery", 
                [
                    new ReferralRule()
                ]),

            new Department(
                "Radiology", 
                [
                    new ReferralRule(), 
                    new FinancialApprovalRule()
                ]),
        ];
    }
}