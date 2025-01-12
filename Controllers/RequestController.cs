using Microsoft.AspNetCore.Mvc;
using Test_Case.Services.Interfaces;
using Test_Case.Models;

namespace Test_Case.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequestController : ControllerBase
{
    private readonly IRequestService _requestService;

    public RequestController(IRequestService requestService)
    {
        _requestService = requestService;
    }

    [HttpPost("create-request/{id}")]
    public async Task<IActionResult> CreateRequest(int id, [FromBody] Request model)
    {
        try
        {
            var user = await _requestService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            var newRequest = await _requestService.CreateRequestAsync(id, model);
            return Ok(new { message = "Request created successfully.", newRequest });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while creating the request.", error = ex.Message });
        }
    }

    [HttpGet("get-request")]
    public async Task<IActionResult> GetAllRequests()
    {
        try
        {
            var requests = await _requestService.GetAllRequestAsync();

            if (requests.Count == 0)
            {
                return NotFound(new { message = "No requests found." });
            }

            return Ok(requests);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while retrieving requests.", error = ex.Message });
        }
    }

    [HttpGet("get-request/{id}")]
    public async Task<IActionResult> GetRequestsByUserId(int id)
    {
        try
        {
            var requests = await _requestService.GetAllRequestByIdAsync(id);
            return Ok(requests);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while retrieving user requests.", error = ex.Message });
        }
    }

    [HttpPut("update-request/{id}")]
    public async Task<IActionResult> UpdateRequest(int id)
    {
        try
        {
            var updatedRequest = await _requestService.UpdateRequestAsync(id);

            if (updatedRequest == null)
            {
                return NotFound(new { message = "Request not found." });
            }

            return Ok(updatedRequest);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while updating the request.", error = ex.Message });
        }
    }
}
