namespace HashSlingerApi.Data;

using Microsoft.EntityFrameworkCore;

public partial class HashSlingerContext : DbContext
{
    public HashSlingerContext(DbContextOptions<HashSlingerContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<Models.User> Users { get; set; } = null!;
}
