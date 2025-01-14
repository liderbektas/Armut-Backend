using Microsoft.AspNetCore.Mvc;
using Test_Case.Models;
using Test_Case.Services.Interfaces;

namespace Test_Case.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("Login")]
    public IActionResult Login([FromBody] User model)
    {
        var user = _authService.FindUser(model.Email);
        if (user == null)
        {
            return NotFound("User not found");
        }

        var token = _authService.GenerateToken(user);
        return Ok(user);
    }

    [HttpPost("Register")]
    public IActionResult Register([FromBody] User user)
    {
        var existUser = _authService.FindUser(user.Email);
        if (existUser != null)
        {
            return BadRequest(new { message = "Bu kullanıcı zaten mevcut" });
        }

        var newUser = _authService.RegisterUser(user);
        var token = _authService.GenerateToken(newUser);

        return Ok(newUser);
    }
}