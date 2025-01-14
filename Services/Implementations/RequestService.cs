using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test_Case.Models;
using Test_Case.Services.Interfaces;

namespace Test_Case.Services.Implementations;

public class RequestService : IRequestService
{
    private readonly LZ_Context _lzContext;

    public RequestService(LZ_Context lzContext)
    {
        _lzContext = lzContext;
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _lzContext.Users.FindAsync(id);
    }

    public async Task<Request> CreateRequestAsync(int id, Request model)
    {
        var user = await GetUserByIdAsync(id);

        var newRequest = new Request()
        {
            ServiceName = model.ServiceName,
            AveragePrice = model.AveragePrice,
            Details = model.Details,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            UserId = user.Id,
            User = user,
            IsAccepted = false
        };

        await _lzContext.Requests.AddAsync(newRequest);
        await _lzContext.SaveChangesAsync();

        return newRequest;
    }

    public async Task<List<Request>> GetAllRequestAsync()
    {
        var requests = await _lzContext.Requests
            .Include(r => r.Details)
            .ToListAsync();

        return requests;
    }

    public async Task<List<Request>> GetAllRequestByIdAsync(int id)
    {
        var requests = await _lzContext.Requests
            .Where(r => r.UserId == id)
            .Include(r => r.Details)
            .ToListAsync();
        
        return requests;
    }

    public async Task<Request> UpdateRequestAsync(int id)
    {
        var request = await _lzContext.Requests
            .Where(r => r.Id == id)
            .Include(r => r.Details)
            .FirstOrDefaultAsync();
        
        request.Status = "inactive";
        await _lzContext.SaveChangesAsync();
        
        return request;
    }
    
    public async Task<List<Request>> GetNotAcceptedRequestsAsync(int providerId)
    {
        var services = await _lzContext.Services
            .Where(s => s.ProviderId == providerId)
            .Select(s => s.Name)
            .ToListAsync();

        return await _lzContext.Requests
            .Where(r => services.Contains(r.ServiceName) && r.Status == "active" && !r.IsAccepted)
            .Include(r => r.Details)
            .Include(r => r.User)
            .ToListAsync();
    }
}