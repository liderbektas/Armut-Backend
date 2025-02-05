using Test_Case.Models;
using Test_Case.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Test_Case.Services.Implementations;

public class ServeService : IServeService
{
    private readonly LZ_Context _lzContext;

    public ServeService(LZ_Context lzContext)
    {
        _lzContext = lzContext;
    }

    public async Task<Service> CreateServeAsync(int id, Service service)
    {
        var user = await _lzContext.Users.FindAsync(id);
        if (user == null)
        {
            return null;
        }
        
        var newService = new Service()
        {
            Name = service.Name,
            Description = service.Description,
            ProviderId = user.Id,
            Category = service.Category,
            IsAvailable = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _lzContext.Services.AddAsync(newService);
        await _lzContext.SaveChangesAsync();
        return newService;
    }

    public async Task<List<Service>> GetServicesByProviderIdAsync(int providerId)
    {
        return await _lzContext.Services
            .Where(s => s.ProviderId == providerId)
            .ToListAsync();
    }
}
