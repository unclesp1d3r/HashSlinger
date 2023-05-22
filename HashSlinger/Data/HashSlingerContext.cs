using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HashSlinger.Data;

public partial class HashSlingerContext : DbContext
{
    public HashSlingerContext(DbContextOptions<HashSlingerContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<Models.User> Users { get; set; } = null!;
}