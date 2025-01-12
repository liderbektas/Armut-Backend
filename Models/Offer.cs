using Test_Case.Models;

public class Offer
{
    public int Id { get; set; }
    public string Blurb { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public int OfferPrice { get; set; }
    public int RequestId { get; set; }
    public Request? Request { get; set; }
    public string Status { get; set; } = "Pending";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}