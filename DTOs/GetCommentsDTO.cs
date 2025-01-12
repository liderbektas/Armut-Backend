namespace Test_Case.Models;

public class GetCommentsDTO
{
        public int Id { get; set; }
        public string Content { get; set; }
        public string AuthorName { get; set; } 
        public string Rate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}