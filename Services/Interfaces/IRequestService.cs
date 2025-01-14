using Test_Case.Models;

namespace Test_Case.Services.Interfaces;

public interface IRequestService
{
    Task<User?> GetUserByIdAsync(int id);
    Task<Request> CreateRequestAsync(int id, Request model);
    Task<List<Request>> GetAllRequestAsync();
    Task<List<Request>> GetAllRequestByIdAsync(int id);
    Task<Request> UpdateRequestAsync(int id);
    Task<List<Request>> GetNotAcceptedRequestsAsync(int providerId);
}
