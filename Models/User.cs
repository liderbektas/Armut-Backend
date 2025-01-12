namespace Test_Case.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty; 
    public string? Phone { get; set; }
    public string Role { get; set; } = "user";
    public bool isVerified { get; set; } = false;
    public string CreditCardNumber { get; set; } = string.Empty;
    public string CreditCardLastMonth { get; set; } = string.Empty;
    public string CreditCardLastYear { get; set; } = string.Empty;
    public string CreditCardCvvCode { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? Rate { get; set; }
    public List<Comment>? SentComments { get; set; }
    public List<Comment>? ReceivedComments { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
