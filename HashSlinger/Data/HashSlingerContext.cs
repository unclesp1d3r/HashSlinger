﻿namespace HashSlinger.Api.Data;

using Microsoft.EntityFrameworkCore;
using Models;

/// <summary>A DbContext instance representing a session with the database.</summary>
/// <autogeneratedoc />
public partial class HashSlingerContext : DbContext
{
    /// <summary>Initializes a new instance of the <see cref="HashSlingerContext" /> class.</summary>
    /// <param name="options">The options.</param>
    /// <autogeneratedoc />
    public HashSlingerContext(DbContextOptions<HashSlingerContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<User> Users { get; set; } = null!;
}
