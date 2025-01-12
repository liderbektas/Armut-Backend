using Microsoft.AspNetCore.Mvc;
using Test_Case.Models;
using Test_Case.Services.Implementations;

namespace Test_Case.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly CommentService _commentService;

    public CommentController(CommentService commentService)
    {
        _commentService = commentService;
    }
    
    [HttpGet("get-comment-by-user/{userId}")]
    public async Task<IActionResult> GetCommentByUserId(int userId)
    {
        try
        {
            var comment = await _commentService.GetCommentByUserIdAsync(userId);
            if (comment == null)
            {
                return NotFound(new { message = "Yorum bulunamadı" });
            }
            return Ok(comment);
            
        }
        catch (Exception ex)
        {
            var errorResponse = new ErrorResponseDTO()
            {
                Message = "An error occurred while retrieving user requests.",
                Error = ex.Message
            };
            return StatusCode(400, errorResponse);
        }
    }
}