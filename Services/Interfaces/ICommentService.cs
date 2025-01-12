using Test_Case.Models;

namespace Test_Case.Services.Interfaces;

public interface ICommentService
{
    Task<List<Comment>> GetCommentByUserIdAsync(int id);
}