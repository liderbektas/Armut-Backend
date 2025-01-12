namespace Test_Case.Models;

public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int AuthorId { get; set; }
    public User? Author { get; set; }
    public int RecipientId { get; set; }
    public User? Recipient { get; set; }
    public string UserRate { get; set; }
}