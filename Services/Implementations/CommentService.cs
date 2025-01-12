using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Test_Case.Models;

namespace Test_Case.Services.Implementations;

public class CommentService
{
    private readonly LZ_Context _lzContext;

    public CommentService(LZ_Context lzContext)
    {
        _lzContext = lzContext;
    }
    
    public async Task<List<GetCommentsDTO>> GetCommentByUserIdAsync(int id)
    {
        var comments = await _lzContext.Comments
            .Where(c => c.RecipientId == id)
            .Include(c => c.Author)
            .ToListAsync();

        var commentDTOs =  comments.Select(c => new GetCommentsDTO()
        {
            Id = c.Id,
            AuthorName = c.Author.Name,
            CreatedAt = c.CreatedAt,
            Content = c.Content,
            Rate = c.UserRate
           
        }).ToList();
        
        return commentDTOs;
    }
}