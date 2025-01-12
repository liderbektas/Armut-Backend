namespace Test_Case.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string ServiceName { get; set; } = string.Empty;
        public string AveragePrice { get; set; } = string.Empty;
        public List<RequestDetails> Details { get; set; } = new List<RequestDetails>(); 
        public string Status { get; set; } = "active";
        public int UserId { get; set; }
        public User? User { get; set; }
        public bool IsAccepted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}