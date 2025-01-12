using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Test_Case.Helpers;
using Test_Case.Models;

namespace Test_Case.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly JwtHelpers _jwtHelpers;
    private readonly LZ_Context _lzContext;

    public AuthController(JwtHelpers jwtHelpers, LZ_Context lzContext)
    {
        _jwtHelpers = jwtHelpers;
        _lzContext = lzContext;
    }

    [HttpPost("Login")]
    public IActionResult Login([FromBody] User model)
    {
        var user = FindUser(model);
        if (user == null)
        {
            return NotFound("User not found");
        }
        
        _jwtHelpers.GenerateToken(user);
        return Ok(user);
    }

    [HttpPost("Register")]
    public IActionResult Register([FromBody] User user)
    {
        var existUser = FindUser(user);
        if (existUser != null)
        {
            return BadRequest(new { message = "Bu kullanıcı zaten mevcut" });
        }

        var newUser = new User()
        {
            Name = user.Name,
            Email = user.Email,
            Password = user.Password,
            CreatedAt = DateTime.Now,
        };
        
        _jwtHelpers.GenerateToken(newUser);
        
        _lzContext.Users.Add(newUser);
        _lzContext.SaveChanges();
        return Ok(newUser);
    }

    public User FindUser(User model)
    {
        return _lzContext.Users
            .FirstOrDefault(u => u.Email == model.Email);
    }
}