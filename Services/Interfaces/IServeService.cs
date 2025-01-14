using Test_Case.Models;

namespace Test_Case.Services.Interfaces;

public interface IServeService
{
    Task<Service> CreateServeAsync(int id, Service service);
    Task<List<Service>> GetServicesByProviderIdAsync(int providerId);
}