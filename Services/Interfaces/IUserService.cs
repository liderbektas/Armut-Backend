using Test_Case.Models;

namespace Test_Case.Services.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetUserByIdAsync(int id);
        Task<List<User>> GetAllUserAsync();
        Task<User> VerifyUserAsync(int id);
        Task<User> UpdateUserAsync(int id, User model);
        Task<User> UpdatePasswordAsync(int id, string currentPassword, string newPassword);
        Task<User> AddPaymentMethodAsync(int id, User model);
    }
}