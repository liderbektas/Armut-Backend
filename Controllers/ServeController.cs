using Microsoft.AspNetCore.Mvc;
using Test_Case.Models;
using Test_Case.Services.Interfaces;

namespace Test_Case.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServeController : ControllerBase
{
    private readonly IServeService _serveService;

    public ServeController(IServeService serveService)
    {
        _serveService = serveService;
    }

    [HttpPost("create-serve/{id}")]
    public async Task<IActionResult> CreateServe(int id, [FromBody] Service service)
    {
        try
        {
            var newService = await _serveService.CreateServeAsync(id, service);

            if (newService == null)
            {
                return BadRequest(new { message = "User not found" });
            }
            return Ok(newService);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal server error", ex.Message });
        }
    }

    [HttpGet("get-serve/{id}")]
    public async Task<IActionResult> GetServeByUserId(int id)
    {
        try
        {
            var services = await _serveService.GetServicesByProviderIdAsync(id);

            if (!services.Any())
            {
                return NotFound(new { message = "No services found" });
            }
            
            return Ok(services);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal server error" , ex.Message });
        }
    }

    [HttpGet("get-not-accepted-request/{id}")]
    public async Task<IActionResult> GetNotAcceptedRequests(int id)
    {
        try
        {
            var requests = await _serveService.GetNotAcceptedRequestsAsync(id);

            if (!requests.Any())
            {
                return NotFound(new { message = "No requests found" });
            }
            
            return Ok(requests);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal server error" , ex.Message });
        }
    }
    
    [HttpGet("get-accepted-request/{id}")]
    public async Task<IActionResult> GetAcceptedRequests(int id)
    {
        try
        {
            var requests = await _serveService.GetAcceptedRequestsAsync(id);

            if (!requests.Any())
            {
                return NotFound(new { message = "No requests found" });
            }
            
            return Ok(requests);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal server error" , ex.Message });
        }
    }
}
