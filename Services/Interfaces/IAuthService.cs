using Test_Case.Models;

namespace Test_Case.Services.Interfaces;

public interface IAuthService
{
    User FindUser(string email);
    User RegisterUser(User user);
    string GenerateToken(User user);
}
