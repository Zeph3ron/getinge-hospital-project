namespace Hospital.Application.Departments;

/// <summary>
/// A central lookup for all supported departments and their rules.
/// </summary>
public class DepartmentRegistry(IEnumerable<Department> departments)
{
    private readonly Dictionary<string, Department> _departments = departments.ToDictionary(d => d.Name);

    /// <summary>
    /// Attempts to retrieve a department by name.
    /// </summary>
    public bool TryGet(string departmentName, out Department department) => _departments.TryGetValue(departmentName, out department!);
}