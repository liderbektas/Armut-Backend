using Test_Case.Services.Interfaces;
namespace Test_Case.Services.Implementations;
using System;
using System.Linq;
using Test_Case.Helpers;
using Test_Case.Models;

public class AuthService : IAuthService
{
    private readonly LZ_Context _lzContext;
    private readonly JwtHelpers _jwtHelpers;

    public AuthService(LZ_Context lzContext, JwtHelpers jwtHelpers)
    {
        _lzContext = lzContext;
        _jwtHelpers = jwtHelpers;
    }

    public User FindUser(string email)
    {
        return _lzContext.Users
            .FirstOrDefault(u => u.Email == email);
    }

    public User RegisterUser(User user)
    {
        var newUser = new User
        {
            Name = user.Name,
            Email = user.Email,
            Password = user.Password,
            CreatedAt = DateTime.Now,
        };
        
        _lzContext.Users.Add(newUser);
        _lzContext.SaveChanges();
        return newUser;
    }

    public string GenerateToken(User user)
    {
        return _jwtHelpers.GenerateToken(user);
    }
}
