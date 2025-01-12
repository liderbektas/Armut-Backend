using Microsoft.EntityFrameworkCore;

namespace Test_Case.Models;

public class LZ_Context : DbContext
{
    public LZ_Context(DbContextOptions<LZ_Context> options) : base(options){}
    public DbSet<User> Users { get; set; }
    public DbSet<Request>? Requests { get; set; }
    public DbSet<Service>? Services { get; set; }
    public DbSet<Offer>? Offers { get; set; }
    public DbSet<Chat>? Chats { get; set; }
    public DbSet<Comment>? Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<User>().HasData(new User()
        {
            Id = 1,
            Name = "admin",
            Email = "admin@admin.com",
            Password = "admin",
            Role = "Admin",
            CreatedAt = DateTime.UtcNow,
            isVerified = true
        });

        // Offer-User Relationship
        modelBuilder.Entity<Offer>()
            .HasOne(o => o.User)
            .WithMany() // Eğer User tarafında Offers koleksiyonu varsa burayı WithMany(o => o.Offers) yapabilirsiniz.
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Restrict); // Cascade Delete yerine Restrict davranışı

        // Offer-Request Relationship
        modelBuilder.Entity<Offer>()
            .HasOne(o => o.Request)
            .WithMany() // Eğer Request tarafında Offers koleksiyonu varsa burayı WithMany(r => r.Offers) yapabilirsiniz.
            .HasForeignKey(o => o.RequestId)
            .OnDelete(DeleteBehavior.Restrict); // Cascade Delete yerine Restrict davranışı
        
        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Author)
            .WithMany(u => u.SentComments)
            .HasForeignKey(c => c.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Recipient)
            .WithMany(u => u.ReceivedComments)
            .HasForeignKey(c => c.RecipientId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}