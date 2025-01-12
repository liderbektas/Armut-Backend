namespace Test_Case.Models;

public class SendMessageDTO
{
    public int UserId { get; set; }
    public int ToUserId { get; set; }
    public string Message { get; set; }
}