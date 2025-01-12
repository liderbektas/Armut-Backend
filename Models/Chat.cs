namespace Test_Case.Models;

public class Chat
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ToUserId { get; set; }
    public string Message { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}