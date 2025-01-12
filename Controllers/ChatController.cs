using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Test_Case.Hubs;
using Test_Case.Models;

namespace Test_Case.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChatController : ControllerBase
{
    private readonly LZ_Context _lzContext;
    private readonly IHubContext<ChatHub> _hubContext;

    public ChatController(LZ_Context lZ_Context, IHubContext<ChatHub> hubContext)
    {
        _lzContext = lZ_Context;
        _hubContext = hubContext;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetChats(int userId, int toUserId, CancellationToken cancellationToken)
    {
        var chats = 
            await _lzContext
                .Chats
                .Where(p => 
                    p.UserId == userId && p.ToUserId == toUserId || 
                    p.ToUserId == userId && p.UserId == toUserId)
                .OrderBy(p=> p.Date)
                .ToListAsync(cancellationToken);

        return Ok(chats);
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage(SendMessageDTO request, CancellationToken cancellationToken)
    {
        Chat chat = new()
        {
            UserId = request.UserId,
            ToUserId = request.ToUserId,
            Message = request.Message,
            Date = DateTime.Now
        };

        await _lzContext.AddAsync(chat, cancellationToken);
        await _lzContext.SaveChangesAsync(cancellationToken);

        var connectionId = ChatHub.Users.First(p => p.Value == chat.ToUserId.ToString()).Key;

        await _hubContext.Clients.Client(connectionId.ToString()).SendAsync("Messages", chat);

        return Ok(chat);
    }
}