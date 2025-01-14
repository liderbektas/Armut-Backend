using Microsoft.AspNetCore.Mvc;
using Test_Case.Models;
using Test_Case.Services.Interfaces;

namespace Test_Case.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet("get-user-by-id/{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        try
        {
            var users = await _userService.GetUserByIdAsync(id);
            return Ok(users);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    public async Task<IActionResult> GettAllUser()
    {
        try
        {
            var users = await _userService.GetAllUserAsync();
            return Ok(users);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> VerifiedUser(int id)
    {
        try
        {
            var user = await _userService.VerifyUserAsync(id);
            return Ok(new { message = "User verified ", user });
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] User model)
    {
        try
        {
            var user = await _userService.UpdateUserAsync(id, model);
            return Ok(new { message = "User updated successfully", user });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("update-password/{id}")]
    public async Task<IActionResult> UpdatePassword(int id, [FromBody] UpdatePasswordModel model)
    {
        try
        {
            var user = await _userService.UpdatePasswordAsync(id, model.Password, model.NewPassword);
            return Ok(new { message = "Şifre başarıyla oluşturulmuştur.", user });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("update-payment/{id}")]
    public async Task<IActionResult> AddPaymentMethod(int id, [FromBody] User model)
    {
        try
        {
            var user = await _userService.AddPaymentMethodAsync(id, model);
            return Ok(new { message = "Ödeme yöntemi başarıyla değiştirildi.", user });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    
    [HttpGet("get-confirmed-user")]
    public async Task<IActionResult> GetAllConfirmedUser()
    {
        try
        {
            var user = await _userService.GetAllConfirmedUserAsync();
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    
    [HttpGet("get-unapproved-user")]
    public async Task<IActionResult> GetAllUnApprovedUser()
    {
        try
        {
            var user = await _userService.GetAllUnApprovedUserAsync();
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
