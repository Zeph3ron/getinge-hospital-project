namespace Hospital.Application;

public interface INationalRegistryService
{
    Task<bool> ValidateCpr(string cpr);
}
